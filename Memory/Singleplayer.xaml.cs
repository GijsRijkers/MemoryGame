using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

using System.Media;
using System.IO;

using System.Xml;


using System.Configuration;


namespace Memory

{
    /// <summary>
    /// Interaction logic for Singleplayer.xaml
    /// </summary>
    public partial class Singleplayer : Window
    {

        private int time = 59;

        private DispatcherTimer Timer;
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        MemoryGrid grid;
        private MainWindow mainWindow;
        private Player uPlayer;

        //MemoryGrid ResetGrid;
        public Singleplayer(MainWindow mainWindow)
        {
            InitializeComponent();
            grid = new MemoryGrid(Gamegrid, NR_OF_COLS, NR_OF_ROWS, this);
            //ResetGrid = new MemoryGrid();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
            this.mainWindow = mainWindow;
            DataContext = this;
            scoreLabel.Content = "Score: " + grid.getScore().ToString();
        }

        public void setPlayer(Player player) { uPlayer = player; }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                if (grid.getImageCount() == 8)
                {
                    grid.setWin();
                    MessageBox.Show("Je hebt gewonnen! \n" + String.Format("00:0{0}:{1}", time / 60, time % 60));
                    Timer.Stop();

                    MessageBox.Show(uPlayer.getName());

                }

                if (time <= 10)
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
                MessageBox.Show("Out of time! Druk op Ok om opnieuw te starten !");
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
            if (btnStartPauze.Content == "Start")
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

        private void SingleplayerClose(object sender, EventArgs e)
        {
            Timer.Stop(); // Timer.Stop toegevoegd aangezien dit nog niet gedaan was.
            mainWindow.Show();
        }

        private void TerugKlick(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Show();

        }

        //Muziek aan/uit buttons.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound);
            player.PlayLooping();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound);
            player.Stop();
        }


            private void ResetTimeKlick(object sender, RoutedEventArgs e)
            {
                this.Close();
                SinglePlayerNameSelect singleplayernameselect = new SinglePlayerNameSelect(this);
                singleplayernameselect.Show();
            }

            public void showScore()
            {
                scoreLabel.Content = "Score: " + grid.getScore();
            }
        }
    }
