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
using System.Media;

namespace Memory
{
    /// <summary>
    /// Interaction logic for Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Window
    {
        private int time = 59;
        
        /// <summary>
        /// Geeft het aantal kolommen in de grid aan
        /// </summary>
        private const int NR_OF_COLS = 4;
        /// <summary>
        /// geeft het aantal rijen in de grid aan
        /// </summary>
        private const int NR_OF_ROWS = 4;
        MultiplayerMemoryGrid grid;

        public MainWindow mainWindow;
        public MultiPlayerNameSelect name;
      

        /// <summary>
        /// Maakt de grid aan en zorgt dat de muziek begint te spelen
        /// </summary>
        public Multiplayer(MainWindow mainWindow, MultiPlayerNameSelect nameSelect)
        {
            InitializeComponent();
            grid = new MultiplayerMemoryGrid(Gamegrid, NR_OF_COLS, NR_OF_ROWS);

            //player.Play();
            name = nameSelect;
            spelerkleur();
        
            

            this.mainWindow = mainWindow;

            


            

        }

        
        
        /// <summary>
        /// Herkent wanneer de pagina gesloten wordt en opent het mainmenu
        /// </summary>
        private void MultiplayerClose(object sender, EventArgs e)
        {
            this.Close();
            this.mainWindow.Show();

            
        }


        /// <summary>
        /// Sluit de pagina wanneer er op de knop van afsluiten aangeklikt wordt sluit de pagina en opent het mainmenu
        /// </summary>
        private void TerugKlick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            this.mainWindow.Show();

        }

        /// <summary>
        /// Checkt welke speler er aan de beurt is en past het label op het gamescherm aan op basis van wie er aan de beurt is
        /// </summary>
        public void spelerkleur()
        {


            if (grid.beurt() == "player1")
            {
                speler1.FontSize = 20;
                speler1.Content = name.ReturnPlayer1() + " score :" + grid.score1();
                speler1.Background = Brushes.Purple;
                speler2.FontSize = 10;
                speler2.Content = name.ReturnPlayer2() + " score :" + grid.score2();
                speler2.Background = Brushes.Transparent;
            }               

                else if (grid.beurt() == "player2")
                {
                speler1.FontSize = 10;
                speler1.Content = name.ReturnPlayer1() + " score :" + grid.score1();
                speler1.Background = Brushes.Transparent;
                speler2.FontSize = 20;
                speler2.Content = name.ReturnPlayer2() + " score :" + grid.score2();
                speler2.Background = Brushes.Purple;
                }
                


        }

        /// <summary>
        /// Wanneer de kaarten op zijn controleert deze methode wiens score het hoogst is en die heeft dan gewonnen
        /// </summary>
        private void CheckWin()
        {

            if (grid.getImageCount() == 8)
            {
                if (grid.score1() < grid.score2())
                {
                    MessageBox.Show(name.ReturnPlayer2() + "heeft gewonnen");
                }
                else if (grid.score1() == grid.score2())
                {
                    MessageBox.Show("Het is gelijkspel");
                }
                else
                {
                    MessageBox.Show(name.ReturnPlayer2() + "heeft gewonnen");
                }
            }
        }

        /// <summary>
        /// Checkt elke keer wanneer er op de grid geklikt wordt wie er aan de beurt is en of de kaarten al op zijn dus wie er gewonnen heeft
        /// </summary>
        private void Gamegrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            spelerkleur();
            CheckWin();
            
        }

        /// <summary>
        /// Reset het programma als het ware doormiddel van het huidige window af te sluiten en een nieuwe select name aan te maken
        /// </summary>
        private void ResetClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MultiPlayerNameSelect multiPlayerNameSelectWin = new MultiPlayerNameSelect(this);
            multiPlayerNameSelectWin.Show();

        }
        /// <summary>
        /// muziek aan button
        /// </summary>
        private void geluidaan_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound);
            player.PlayLooping();

        }

        /// <summary>
        /// muziek uit button
        /// </summary>
        private void Geluiduit_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound);
            player.Stop();
        }
    }
}
