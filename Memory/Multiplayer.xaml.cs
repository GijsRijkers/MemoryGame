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
        
        
        private const int NR_OF_COLS = 4;
        private const int NR_OF_ROWS = 4;
        MultiplayerMemoryGrid grid;

        public MainWindow mainWindow;
        public MultiPlayerNameSelect name;
      
        public Multiplayer(MainWindow mainWindow, MultiPlayerNameSelect nameSelect)
        {
            InitializeComponent();
            grid = new MultiplayerMemoryGrid(Gamegrid, NR_OF_COLS, NR_OF_ROWS);
            //name = new MultiPlayerNameSelect(ReturnPlayer1);
            //ResetGrid = new MemoryGrid(); 
            name = nameSelect;
            spelerkleur();
            //ResetGrid = new MemoryGrid();
            

            this.mainWindow = mainWindow;

            



            //MultiplayerMemoryGrid t = multiplayerMemoryGrid;

        }

       
        //public void setPlayer(MulitplayerPlayers player) { player1 = player; }
        

        private void MultiplayerClose(object sender, EventArgs e)
        {
            this.Close();
            mainWindow.Close();

            
        }

        private void TerugKlick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow.Show();

        }

        
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

        private void CheckWin()
        {

            if (grid.getImageCount() == 8)
            {
                if (grid.score1() < grid.score2())
                {
                    MessageBox.Show(name.ReturnPlayer2() + " heeft gewonnen🎈🎉");
                    this.Hide();
                    mainWindow.Show();
                }
                else if (grid.score1() == grid.score2())
                {
                    MessageBox.Show("Het is gelijkspel🎈🎉");
                }

                else
                {
                    MessageBox.Show(name.ReturnPlayer2() + " heeft gewonnen🎈🎉");
                    this.Hide();
                    mainWindow.Show();
                }
            }
        }

        private void Gamegrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            spelerkleur();
            CheckWin();
            
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MultiPlayerNameSelect multiPlayerNameSelectWin = new MultiPlayerNameSelect(this);
            multiPlayerNameSelectWin.Show();

        }
        //Muziek aan/uit buttons.
        private void geluidaan_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound);
            player.PlayLooping();

        }

        private void Geluiduit_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound);
            player.Stop();
        }
    }
}
