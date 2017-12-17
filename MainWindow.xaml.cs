using System;
using System.ComponentModel;
using System.Collections.Generic;
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
            var window_thread = new Thread(InitializeMetronomeGrid);    // Allows metronome to "pulse" in background while GUI waits on events
            window_thread.SetApartmentState(ApartmentState.STA);
            window_thread.IsBackground = true;                      // Ensures that window_thread is closed when application is closed
            window_thread.Start();
        }

        // Metronome Global Variables
        private int pulse;
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

        private void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TextBlock txtPulse;
        public void InitializeMetronomeGrid()
        {
            Grid metronomeGrid = new Grid();
            metronomeGrid.Width = 500;
            metronomeGrid.Height = 400;
            metronomeGrid.HorizontalAlignment = HorizontalAlignment.Left;
            metronomeGrid.VerticalAlignment = VerticalAlignment.Top;
            metronomeGrid.ShowGridLines = false;

            ColumnDefinition colDef1 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef1);
            ColumnDefinition colDef2 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef2);
            ColumnDefinition colDef3 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef3);
            ColumnDefinition colDef4 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef4);
            ColumnDefinition colDef5 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef5);
            ColumnDefinition colDef6 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef6);
            ColumnDefinition colDef7 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef7);
            ColumnDefinition colDef8 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef8);
            ColumnDefinition colDef9 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef9);
            ColumnDefinition colDef10 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef10);

            ColumnDefinition colDef11 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef11);
            ColumnDefinition colDef12 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef12);
            ColumnDefinition colDef13 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef13);
            ColumnDefinition colDef14 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef14);
            ColumnDefinition colDef15 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef15);
            ColumnDefinition colDef16 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef16);
            ColumnDefinition colDef17 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef17);
            ColumnDefinition colDef18 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef18);
            ColumnDefinition colDef19 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef19);
            ColumnDefinition colDef20 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef20);

            ColumnDefinition colDef21 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef21);
            ColumnDefinition colDef22 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef22);
            ColumnDefinition colDef23 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef23);
            ColumnDefinition colDef24 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef24);
            ColumnDefinition colDef25 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef25);
            ColumnDefinition colDef26 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef26);
            ColumnDefinition colDef27 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef27);
            ColumnDefinition colDef28 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef28);
            ColumnDefinition colDef29 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef29);
            ColumnDefinition colDef30 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef30);

            ColumnDefinition colDef31 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef31);
            ColumnDefinition colDef32 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef32);
            ColumnDefinition colDef33 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef33);
            ColumnDefinition colDef34 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef34);
            ColumnDefinition colDef35 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef35);
            ColumnDefinition colDef36 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef36);
            ColumnDefinition colDef37 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef37);
            ColumnDefinition colDef38 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef38);
            ColumnDefinition colDef39 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef39);
            ColumnDefinition colDef40 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef40);

            ColumnDefinition colDef41 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef41);
            ColumnDefinition colDef42 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef42);
            ColumnDefinition colDef43 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef43);
            ColumnDefinition colDef44 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef44);
            ColumnDefinition colDef45 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef45);
            ColumnDefinition colDef46 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef46);
            ColumnDefinition colDef47 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef47);
            ColumnDefinition colDef48 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef48);
            ColumnDefinition colDef49 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef49);
            ColumnDefinition colDef50 = new ColumnDefinition();
            metronomeGrid.ColumnDefinitions.Add(colDef50);

            RowDefinition rowDef1 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef1);
            RowDefinition rowDef2 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef2);
            RowDefinition rowDef3 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef3);
            RowDefinition rowDef4 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef4);
            RowDefinition rowDef5 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef5);
            RowDefinition rowDef6 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef6);
            RowDefinition rowDef7 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef7);
            RowDefinition rowDef8 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef8);
            RowDefinition rowDef9 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef9);
            RowDefinition rowDef10 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef10);

            RowDefinition rowDef11 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef11);
            RowDefinition rowDef12 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef12);
            RowDefinition rowDef13 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef13);
            RowDefinition rowDef14 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef14);
            RowDefinition rowDef15 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef15);
            RowDefinition rowDef16 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef16);
            RowDefinition rowDef17 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef17);
            RowDefinition rowDef18 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef18);
            RowDefinition rowDef19 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef19);
            RowDefinition rowDef20 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef20);

            RowDefinition rowDef21 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef21);
            RowDefinition rowDef22 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef22);
            RowDefinition rowDef23 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef23);
            RowDefinition rowDef24 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef24);
            RowDefinition rowDef25 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef25);
            RowDefinition rowDef26 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef26);
            RowDefinition rowDef27 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef27);
            RowDefinition rowDef28 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef28);
            RowDefinition rowDef29 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef29);
            RowDefinition rowDef30 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef30);

            RowDefinition rowDef31 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef31);
            RowDefinition rowDef32 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef32);
            RowDefinition rowDef33 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef33);
            RowDefinition rowDef34 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef34);
            RowDefinition rowDef35 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef35);
            RowDefinition rowDef36 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef36);
            RowDefinition rowDef37 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef37);
            RowDefinition rowDef38 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef38);
            RowDefinition rowDef39 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef39);
            RowDefinition rowDef40 = new RowDefinition();
            metronomeGrid.RowDefinitions.Add(rowDef40);

            TextBlock txtBPM = new TextBlock();
            txtBPM.Text = "BPM=120";
            txtBPM.FontSize = 16;
            txtBPM.FontWeight = FontWeights.Normal;
            Grid.SetColumn(txtBPM, 0);
            Grid.SetColumnSpan(txtBPM, 7);
            Grid.SetRow(txtBPM, 0);
            Grid.SetRowSpan(txtBPM, 2);

            pulse = 0;
            Pulse_Cnt = String.Format("{0}", pulse);
            Main();
        }

        // Main() for metronome background operation
        public void Main()
        {
            for(;;)
            {
                Pulse_Cnt = String.Format("{0}", ++pulse);
                pulse %= 4;
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}