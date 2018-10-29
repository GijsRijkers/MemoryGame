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
    /// Interaction logic for SinglePlayerNameSelect.xaml
    /// </summary>
    public partial class SinglePlayerNameSelect : Window
    {

        private MainWindow mainWindow;
        private Singleplayer singlePlayer;

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

            SingleplayerWin.Show();
        }

        public String getUserNameP1()
        {
            return userNameP1;
        }
    }
}
