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
        private int pulse;
        private int met_cnt;
        private int tempo;
        private int tsnum;
        private int tsden;
        // Binding logic for pulse count output to UI
        private string pulse_cnt;
        public string Pulse_Cnt
        {
            get { return pulse_cnt; }
            set
            {
                pulse_cnt = value;
                OnPropertyChanged("Pulse_Cnt");
            }
        }

        // Binding logic for bpm setting output to UI
        private string bpm;
        public string BPM
        {
            get { return bpm; }
            set
            {
                bpm = value;
                OnPropertyChanged("BPM");
            }
        }

        // Binding logic for time signature numerator setting output to UI
        private string tsnumerator;
        public string TSNumerator
        {
            get { return tsnumerator; }
            set
            {
                tsnumerator = value;
                OnPropertyChanged("TSNumerator");
            }
        }

        // Binding logic for time signature denominator setting output to UI
        private string tsdenominator;
        public string TSDenominator
        {
            get { return tsdenominator; }
            set
            {
                tsdenominator = value;
                OnPropertyChanged("TSDenominator");
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

        // Main() for metronome background operation
        private static int BPM_INC = 4;
        public void Main()
        {
            pulse = 0;
            Pulse_Cnt = String.Format("{0}", pulse);

            tempo = 120;
            BPM = String.Format("BPM={0}", tempo);

            tsnum = 4;
            TSNumerator = String.Format("{0}", tsnum);

            tsden = 4;
            TSDenominator = String.Format("{0}", tsden);
            for(;;)
            {
                Pulse_Cnt = String.Format("{0}", ++pulse);
                pulse %= tsnum;
                met_cnt = 60 * 1000 / tempo;
                System.Threading.Thread.Sleep(met_cnt);
            }
        }

        // Button Event Handlers
        private void TempoPlus_Click(object sender, RoutedEventArgs e)
        {
            tempo += BPM_INC;
            BPM = String.Format("BPM={0}", tempo);
            met_cnt = 60 * 1000 / tempo;
        }

        private void TempoMinus_Click(object sender, RoutedEventArgs e)
        {
            tempo -= BPM_INC;
            BPM = String.Format("BPM={0}", tempo);
            met_cnt = 60 * 1000 / tempo;
        }

        private void TSNumeratorPlus_Click(object sender, RoutedEventArgs e)
        {
            tsnum++;
            if(tsnum > 32) {
                tsnum = 32;
            }
            TSNumerator = String.Format("{0}", tsnum);
        }

        private void TSNumeratorMinus_Click(object sender, RoutedEventArgs e)
        {
            tsnum--;
            if(tsnum <= 0)
            {
                tsnum = 1;
            }
            TSNumerator = String.Format("{0}", tsnum);
        }

        private void TSDenominatorPlus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TSDenominatorMinus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}