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

        public String userNameP1 { get; set; }

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

            // Het verbinden van de path die nodig is om de usernames op te slaan in de uNames map.
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string path = string.Format("{0}Resources\\uNames\\" + userNameP1 + ".txt", System.IO.Path.GetFullPath(System.IO.Path.Combine(RunningPath, @"..\..\")));


            // Checken of file bestaat, zo niet, maak dan 1 aan.
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine(userNameP1);
                }

            }
            // Als bestand al bestaat, overwrite deze.
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine(userNameP1);
                }
            }

            SingleplayerWin.Show();
        }
    }
}
