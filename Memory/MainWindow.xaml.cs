using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int time = 15;
        private DispatcherTimer Timer;
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        MemoryGrid grid;


        public MainWindow()
        {
            InitializeComponent();
            grid = new MemoryGrid(Gamegrid, NR_OF_COLS, NR_OF_ROWS);
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0,0,1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 10)
            {
                if(time <= 10)
                {
                    if (time % 2 == 0)
                    {
                        TBCountDown.Foreground = Brushes.Yellow;
                    }
                    else
                    {
                        TBCountDown.Foreground = Brushes.White;
                    }
                }
                time--;
                TBCountDown.Text = String.Format("00:0{0}:{1}", time / 60, time % 60);
            }
            else
            {
                Timer.Stop();
                MessageBox.Show("HOOOOO !");
            }
        }
    } 
}
