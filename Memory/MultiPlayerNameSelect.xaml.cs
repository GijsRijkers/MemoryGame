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
        public string player1;
        public string player2;

        /// <summary>
        /// Set dit als mainwindow in?
        /// </summary>
        /// <param name="mainWindow"></param>
        public MultiPlayerNameSelect(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        /// <summary>
        /// stelt dit in als multiplayer?
        /// </summary>

        public MultiPlayerNameSelect(Multiplayer multiPlayer)
        {
            InitializeComponent();
            this.multiPlayer = multiPlayer;
        }


        /// <summary>
        /// Sluit bij het drukken van de knop deze window en opent de mainwindow
        /// </summary>

        private void BackToMainMenuClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Show();
        }

        /// <summary>
        /// Returnt speler 1 zodat hij later herroepen kan worden
        /// </summary>
        /// <returns></returns>
        public string ReturnPlayer1()
        {
            return player1;
        }

        /// <summary>
        /// Returnt speler 2 zodat hij later herroepen kan worden
        /// </summary>
        /// <returns></returns>
        public string ReturnPlayer2()
        {
            return player2;
        }

        /// <summary>
        /// Op het drukken van de knop sluit deze window en worden de variabelen player1 en player2 naar de ingevoerde namen geset
        /// en opent daarna het multiplayer gamescherm
        /// </summary>
        private void startMpGame(object sender, RoutedEventArgs e)
        {
            player1 = Player1.Text;
            player2 = Player2.Text;
            this.Close();
            Multiplayer MultiplayerWin = new Multiplayer(mainWindow, this);

            MultiplayerWin.Show();
        }
    }
}
