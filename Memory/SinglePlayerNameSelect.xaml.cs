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

namespace Memory
{
    /// <summary>
    /// Interaction logic for SinglePlayerNameSelect.xaml
    /// </summary>
    public partial class SinglePlayerNameSelect : Window
    {

        private MainWindow mainWindow;
        private Singleplayer singlePlayer;
        private double uHighScore;
        private Player tempPlayerOne;

        public string userNameP1 { get; set; }

        public SinglePlayerNameSelect(MainWindow mainWindow)
        { 
            InitializeComponent();
            this.mainWindow = mainWindow;
            DataContext = this;
        }

        public SinglePlayerNameSelect(Singleplayer singlePlayer)
        {
            InitializeComponent();
            this.singlePlayer = singlePlayer;
        }

        private void BackToMainMenuClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Show();
        }
  
        // Start SinglePlayer Game. 
        private void startSpGame(object sender, RoutedEventArgs e)
        {
            this.Close();
            Singleplayer SingleplayerWin = new Singleplayer(mainWindow);
            userNameP1 = userNameP1.ToString();
            uHighScore = 0;

            tempPlayerOne = new Player(userNameP1, uHighScore);
            SingleplayerWin.setPlayer(tempPlayerOne);
            SingleplayerWin.Show();
        }
    }

    //class XML
      //  {
        //static void Main (string[] args)
          //  {
            //XmlWriter xmlWriter = XmlWriter.Create("TEST.xml");

            //xmlWriter.WriteStartDocument();
            //xmlWriter.WriteStartElement("userNameP1");

            //xmlWriter.WriteEndElement();

            //xmlWriter.WriteEndDocument();
            //xmlWriter.Close();

      //  }
   // }
}
