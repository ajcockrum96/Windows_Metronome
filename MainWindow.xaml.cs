using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Windows_Metronome
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // Constructor
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            var window_thread = new Thread(Main);                   // Allows metronome to "pulse" in background while GUI waits on events
            window_thread.SetApartmentState(ApartmentState.STA);
            window_thread.IsBackground = true;                      // Ensures that window_thread is closed when application is closed
            window_thread.Start();
        }

        // Metronome Global Variables
        private int beat_length;    // Length of beat in terms of MAX_DEN notes
        private int pulse_length;   // Length of beat in terms of MAX_DEN notes
        private int pulse_count;      // Number of MAX_DEN notes since last pulse
        private int met_wait;    // Number of milliseconds between MAX_DEN notes at given tempo

        // Binding logic for pulse count output to UI
        private int current_pulse;
        public int Current_Pulse
        {
            get { return current_pulse + 1; }
            set
            {
                current_pulse = value;
                OnPropertyChanged("Current_Pulse");
            }
        }

        // Binding logic for tempo setting output to UI
        private int tempo;
        public int Tempo
        {
            get { return tempo; }
            set
            {
                tempo = value;
                OnPropertyChanged("Tempo");
            }
        }

        // Binding logic for time signature numerator setting output to UI
        private int tsnumerator;
        public int TSNumerator
        {
            get { return tsnumerator; }
            set
            {
                tsnumerator = value;
                OnPropertyChanged("TSNumerator");
            }
        }

        // Binding logic for time signature denominator setting output to UI
        private int tsdenominator;
        public int TSDenominator
        {
            get { return tsdenominator; }
            set
            {
                tsdenominator = value;
                OnPropertyChanged("TSDenominator");
            }
        }

        // Binding logic for time signature beat setting output to UI
        private string tsbeat;
        public string TSBeat
        {
            get { return tsbeat; }
            set
            {
                tsbeat = value;
                OnPropertyChanged("TSBeat");
            }
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Metronome "Macros"
        private static int TEMPO_INC = 4;
        private static int MAX_TEMPO = 240;
        private static int MIN_TEMPO = 4;
        private static int MAX_DEN = 16;    // Set 16th note as shortest pulse length
        private static int MIN_DEN = 2;     // Set half note as longest pulse length
        private static int MAX_NUM = 32;
        private static int MIN_NUM = 1;

        // Main() for metronome background operation
        public void Main()
        {
            TSNumerator = 4;
            TSDenominator = 4;

            pulse_length = MAX_DEN / TSDenominator;
            beat_length = pulse_length;
            TSBeat = "Quarter";

            Current_Pulse = 1;

            Tempo = 120;
            met_wait = 60 * 1000 / (Tempo * beat_length);

            for(;;)
            {
                pulse_count = (pulse_count + 1) % pulse_length;
                if(pulse_count == 0)
                {
                    Current_Pulse = Current_Pulse % TSNumerator;
                }
                System.Threading.Thread.Sleep(met_wait);
            }
        }

        // Button Event Handlers
        private void TempoPlus_Click(object sender, RoutedEventArgs e)
        {
            Tempo += TEMPO_INC;
            if(Tempo > MAX_TEMPO)
            {
                Tempo = MAX_TEMPO;
            }
            met_wait = 60 * 1000 / (tempo * beat_length);
        }

        private void TempoMinus_Click(object sender, RoutedEventArgs e)
        {
            Tempo -= TEMPO_INC;
            if(Tempo < MIN_TEMPO)
            {
                Tempo = MIN_TEMPO;
            }
            met_wait = 60 * 1000 / (tempo * beat_length);
        }

        private void TSNumeratorPlus_Click(object sender, RoutedEventArgs e)
        {
            TSNumerator++;
            if(TSNumerator > MAX_NUM) {
                TSNumerator = MAX_NUM;
            }
            ResetMetronome();
        }

        private void TSNumeratorMinus_Click(object sender, RoutedEventArgs e)
        {
            TSNumerator--;
            if(TSNumerator < MIN_NUM)
            {
                TSNumerator = MIN_NUM;
            }
            ResetMetronome();
        }

        private void TSDenominatorPlus_Click(object sender, RoutedEventArgs e)
        {
            TSDenominator *= 2;
            if(TSDenominator > MAX_DEN)
            {
                TSDenominator = MAX_DEN;
            }
            pulse_length = MAX_DEN / TSDenominator;
            ResetMetronome();
        }

        private void TSDenominatorMinus_Click(object sender, RoutedEventArgs e)
        {
            TSDenominator /= 2;
            if(TSDenominator < MIN_DEN)
            {
                TSDenominator = MIN_DEN;
            }
            pulse_length = MAX_DEN / TSDenominator;
            ResetMetronome();
        }

        private void ResetMetronome()
        {
            pulse_count = 0;
            Current_Pulse = 1;
        }

        private void TSBeatPlus_Click(object sender, RoutedEventArgs e)
        {
            if(MAX_DEN == 16) {
                switch (beat_length)
                {
                    case (1):
                        // Becomes 2
                        TSBeat = "8th";
                        beat_length += 1;
                        break;
                    case (2):
                        // Becomes 3
                        TSBeat = "Dotted 8th";
                        beat_length += 1;
                        break;
                    case (3):
                        // Becomes 4
                        TSBeat = "Quarter";
                        beat_length += 1;
                        break;
                    case (4):
                        // Becomes 6
                        TSBeat = "Dotted Quarter";
                        beat_length += 2;
                        break;
                    case (6):
                        // Becomes 8
                        TSBeat = "Half";
                        beat_length += 2;
                        break;
                }
            }
            met_wait = 60 * 1000 / (tempo * beat_length);
            ResetMetronome();
        }

        private void TSBeatMinus_Click(object sender, RoutedEventArgs e)
        {
            if(MAX_DEN == 16) {
                switch (beat_length)
                {
                    case (2):
                        // Becomes 1
                        TSBeat = "16th";
                        beat_length -= 1;
                        break;
                    case (3):
                        // Becomes 2
                        TSBeat = "8th";
                        beat_length -= 1;
                        break;
                    case (4):
                        // Becomes 3
                        TSBeat = "Dotted 8th";
                        beat_length -= 1;
                        break;
                    case (6):
                        // Becomes 4
                        TSBeat = "Quarter";
                        beat_length -= 2;
                        break;
                    case (8):
                        // Becomes 6
                        TSBeat = "Dotted Quarter";
                        beat_length -= 2;
                        break;
                }
            }
            met_wait = 60 * 1000 / (tempo * beat_length);
            ResetMetronome();
        }
    }
}