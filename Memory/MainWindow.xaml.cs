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
        private int time = 59;

        private DispatcherTimer Timer;
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        MemoryGrid grid;
        //MemoryGrid ResetGrid;


        public MainWindow()
        {
            InitializeComponent();
            grid = new MemoryGrid(Gamegrid, NR_OF_COLS, NR_OF_ROWS);
            //ResetGrid = new MemoryGrid();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0,0,1);
            Timer.Tick += Timer_Tick;
            Timer.Start();

        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                if(time <= 10)
                {
                    if (time % 2 == 0)
                    {
                        TBCountDown.Foreground = Brushes.Red;
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
                // niet gelukt, andere oplossing (tijdelijk) gevonden 
                //MemoryGrid t = ResetGrid;
                MessageBox.Show("Out of time Druk op Ok om opnieuw te starten !");
                // dit zorgt dat de huidige spel afgesloten
                Application.Current.Shutdown();
                // dit zorgt om opniew te beginnen
                System.Windows.Forms.Application.Restart();
                TimeSpan t = new TimeSpan();
                

            }
        }

        private void btnStartPauze_Click(object sender, RoutedEventArgs e)
        {
            btnStartPauze.Content = btnStartPauze.Content == "Start" ? "Pause" : "Start";
            if(btnStartPauze.Content == "Start")
            {
                MessageBox.Show("Pause Game");
                Timer.Stop();
            }
            else
            {
                MessageBox.Show("Start Game");
                Timer.Start();
                
            }
            
        }
    } 
}
