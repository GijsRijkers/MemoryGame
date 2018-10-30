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
    /// Objecten van andere classes worden meegegeven zodat deze gebruikt kunnen worden binnen deze class.
    /// </summary>
    public partial class Singleplayer : Window
    {
        private int time = 59;

    
        private DispatcherTimer Timer;
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        MemoryGrid grid;
        private MainWindow mainWindow;
        public Player uPlayer;

        /// <summary>
        /// Dit is de constructor van de Singleplayer class. In de constructor wordt alles wat voorbereid moet worden, voorbereid. 
        /// </summary>
        /// <param name="mainWindow">MainWindow, de naam van het object: MainWindow.</param>
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

        /// <summary>
        /// Deze functie zet de naam van de speler. Zodat de naam in elke class gebruikt kan worden.
        /// </summary>
        /// <param name="player">Naam van het object Player</param>
        public void setPlayer(Player player) { uPlayer = player; }

        /// <summary>
        ///  Deze functie bevat alle functionaliteit van de timer die gebruikt wordt tijdens het spelen van de game.
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of EventArgs (actionlistener)</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                // Controleert of de gebruiker daadwerkelijk heeft gewonnen. Wanneer de getImageCount 8 is, dan heeft de speler alle kaarten omgedraaid.
                if (grid.getImageCount() == 8)
                {
                    grid.setWin();
                    MessageBox.Show("Je hebt gewonnen! \n" + String.Format("00:0{0}:{1}", time / 60, time % 60));
                    Timer.Stop();

                    // De highscore van de speler wordt gekoppeld aan de speler. 
                    //uPlayer.setHighScore(grid.getScore());
                }

                // Als de tijd kleiner is dan 10 seconden....
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of EventArgs (actionlistener)</param>
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

        /// <summary>
        /// Knop, Sluit de Singleplayer (difficult) game af. De timer stopt en de gebruiker wordt doorverwezen naar het main-menu
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of EventArgs</param>
        private void SingleplayerClose(object sender, EventArgs e)
        {
            Timer.Stop(); // Timer.Stop toegevoegd aangezien dit nog niet gedaan was.
           
            mainWindow.Show();
        }

        /// <summary>
        /// Knop, Gaat terug naar het main-menu. 
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of EventArgs</param>
        private void TerugKlick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow.Show();

        }

        /// <summary>
        /// Knop, speelt muziek af
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of EventArgs (actionlistener)</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound);
            player.PlayLooping();
        }

        /// <summary>
        /// Knop, stopt muziek dat aan het afspelen is.
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of EventArgs (actionlistener)</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound);
            player.Stop();
        }

        /// <summary>
        /// Knop, reset de tijd.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Name of Eventargs (eventlistener)</param>
        private void ResetTimeKlick(object sender, RoutedEventArgs e)
        {
            this.Close();
            SinglePlayerNameSelect singleplayernameselect = new SinglePlayerNameSelect(this);
            singleplayernameselect.Show();
        }

        /// <summary>
        /// Laat de score zien die de speler heeft behaald. Dit kan tijdens de game aangeroepen worden, of na de game. 
        /// </summary>
        public void showScore()
        {
          scoreLabel.Content = "Score: " + grid.getScore();
        }
    }
 }
