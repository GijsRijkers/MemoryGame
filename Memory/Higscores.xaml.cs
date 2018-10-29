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
using System.Windows.Shapes;

namespace Memory
{
    /// <summary>
    /// Interaction logic for Higscores.xaml
    /// </summary>
    public partial class Higscores : Window
    {
        private MainWindow mainWindow;
        public Higscores(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        
        private void MainMenuClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Show();

        }
    }
}
