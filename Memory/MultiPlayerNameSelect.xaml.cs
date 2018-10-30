using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MultiPlayerNameSelect.xaml
    /// </summary>
    public partial class MultiPlayerNameSelect : Window
    {
        
        private MainWindow mainWindow;
        private Multiplayer multiPlayer;
        //private MulitplayerPlayers player1;
        public string player1;
        public string player2;

        //public string userNameP1 { get; set; }
        //public string userNameP2 { get; set; }
        public MultiPlayerNameSelect(MainWindow mainWindow)
        {
            
            InitializeComponent();
            this.mainWindow = mainWindow;
            //DataContext = this;
        }

        public MultiPlayerNameSelect(Multiplayer multiPlayer)
        {

            InitializeComponent();
            this.multiPlayer = multiPlayer;
            


        }

        private void BackToMainMenuClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            
            mainWindow.Show();
        }

        public string ReturnPlayer1()
        {
            
            return player1;
        }

        public string ReturnPlayer2()
        {
            
            return player2;
        }


        private void startMpGame(object sender, RoutedEventArgs e)
        {
            player1 = Player1.Text;
            player2 = Player2.Text;
            this.Close();
            Multiplayer MultiplayerWin = new Multiplayer(mainWindow, this);
            //userNameP1 = userNameP1.ToString();
            //userNameP2 = userNameP2.ToString();

            
            
            MultiplayerWin.Show();

          
        }


    }
}
