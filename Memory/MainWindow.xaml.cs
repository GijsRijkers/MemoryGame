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
        
        
        //MemoryGrid ResetGrid;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
           Close();
        }
        
        // Opent nameselect window voor SinglePlayer game.
        private void ShowNameSelectSP(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SinglePlayerNameSelect nameSelect = new SinglePlayerNameSelect(this);
            nameSelect.Show();
        }

        private void MultiplayerClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MultiPlayerNameSelect multiPlayerNameSelectWin = new MultiPlayerNameSelect(this);
            multiPlayerNameSelectWin.Show();
        }

        private void HigscoresClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            //Higscores higscoresWin = new Higscores(this);
            //higscoresWin.Show();

        }
        /// <summary>
        /// knop, zet muziek aan.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound);
            player.Stop();
        }


            //SerializableAttribute;
            /// <summary>
            /// knop, zet muziek uit.
            /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sound);
            player.Play();
        }
    } 
}
