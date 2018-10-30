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
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;

namespace Memory
{
    /// <summary>
    /// Interaction logic for SinglePlayerNameSelect.xaml
    /// Objecten van andere classes worden meegegeven zodat deze gebruikt kunnen worden binnen deze class.
    /// </summary>
    public partial class SinglePlayerNameSelect : Window
    {

        private MainWindow mainWindow;
        private Singleplayer singlePlayer;
        private double uHighScore;
        private Player tempPlayerOne;
        private SingleplayerEasy singleplayerEasy;

        /// <summary>
        /// UsernameP1 is de naam die ingevuld wordt in de textBox met de binding: UserNameP1.
        /// </summary>
        public string userNameP1 { get; set; }

        /// <summary>
        /// Constructor van de SinglePlayerNameSelect class. In deze class worden alle voorbereidingen, voorbereid. 
        /// </summary>
        /// <param name="mainWindow">mainWindow is de naam van het object: MainWindow.</param>
        public SinglePlayerNameSelect(MainWindow mainWindow)
        { 
            InitializeComponent();
            this.mainWindow = mainWindow;
            DataContext = this;
        }

        /// <summary>
        /// Constructor van de SinglePlayerNameSelect class. In deze class worden alle voorbereidingen, voorbereid. 
        /// </summary>
        /// <param name="singlePlayer">singlePlayer is de naam van het object: SinglePlayer.</param>
        public SinglePlayerNameSelect(Singleplayer singlePlayer)
        {
            InitializeComponent();
            this.singlePlayer = singlePlayer;
        }
        
        public SinglePlayerNameSelect(SingleplayerEasy singleplayerEasy)
        {
            this.singleplayerEasy = singleplayerEasy;
        }

        /// <summary>
        /// Knop, stuurt speler terug naar main-menu wanneer deze getriggered wordt. 
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of EventArgs (actionlistener)</param>
        private void BackToMainMenuClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Show();
           
        }
  
        /// <summary>
        /// Knop, Start de Singleplayer game op moeilijk niveau wanneer deze getriggered wordt. 
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of EventArgs (actionlistener)</param>
        private void startSpGame(object sender, RoutedEventArgs e)
        {
            this.Close();
            
            //Creeer een nieuw object SinglePlayerWin(dow).
            Singleplayer SingleplayerWin = new Singleplayer(mainWindow);
             userNameP1 = userNameP1.ToString();
            uHighScore = 0;

            userNameP1 = userNameP1.ToString();
            uHighScore = 0;
        }

        /// <summary>
        /// Start het makkelijke spel van singleplayer
        /// </summary>
        private void startSpGameEasy(object sender, RoutedEventArgs e)
        {
            this.Close();
            SingleplayerEasy SingleplayerEasyWin = new SingleplayerEasy(mainWindow);
            userNameP1 = userNameP1.ToString();
            uHighScore = 0;

            userNameP1 = userNameP1.ToString();
            uHighScore = 0;


            /*
             * Creeert een nieuw object van Player.
             * Vult de parameters met de juiste variabelen
             * Laat het scherm SinglePlayerWin zien. 
             * */
            tempPlayerOne = new Player(userNameP1, uHighScore);
            SingleplayerWin.setPlayer(tempPlayerOne);

            SingleplayerWin.Show();
        }
    }
}
