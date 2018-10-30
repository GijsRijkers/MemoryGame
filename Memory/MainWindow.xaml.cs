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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.sound);
        //MemoryGrid ResetGrid;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        // Opent nameselect window voor SinglePlayer game.
        private void ShowNameSelectSP(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SinglePlayerNameSelect nameSelect = new SinglePlayerNameSelect(this);
            nameSelect.Show();
        }

        private void MulyiplayerClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Multiplayer multiplayerWin = new Multiplayer(this);
            multiplayerWin.Show();
        }

        private void HigscoresClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            //Higscores higscoresWin = new Higscores(this);
            //higscoresWin.Show();

        }
    } 
}
