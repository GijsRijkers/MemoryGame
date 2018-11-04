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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Excel.Application xlApp;
        public Excel.Workbook xlWorkBook;
        public Excel.Worksheet xlWorkSheet;
        public object misValue;

        /// <summary>
        /// Constructor van de MainWindow class (deze). 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            initializeWorkSheet();
            this.xlApp = new Microsoft.Office.Interop.Excel.Application();
            this.misValue = System.Reflection.Missing.Value;
            this.xlWorkBook = xlApp.Workbooks.Add(misValue);
            this.xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);
        }

        /// <summary>
        /// Knop, Sluit de applicatie
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of Args (actionlistener)</param>
        private void CloseApp(object sender, RoutedEventArgs e)
        {
           Close();
        }

        /// <summary>
        /// Opent nameselect window voor SinglePlayer game.
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of Args (actionlistener)</param>
        private void ShowNameSelectSP(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SinglePlayerNameSelect nameSelect = new SinglePlayerNameSelect(this);
            nameSelect.Show();
        }

        /// <summary>
        /// Knop, stuurt de speler naar de MultiPlayerNameSelect window.
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of Args (actionlistener)</param>
        private void MultiplayerClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MultiPlayerNameSelect multiPlayerNameSelectWin = new MultiPlayerNameSelect(this);
            multiPlayerNameSelectWin.Show();
        }

        /// <summary>
        /// Knop, stuurt de speler naar de highscore window.
        /// </summary>
        /// <param name="sender">Sender, de gebruiker</param>
        /// <param name="e">Name of EventArgs (actionlistener)</param>
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

        /// <summary>
        /// Zoekt de Excel worksheet voor de highscores.
        /// </summary>
        private void initializeWorkSheet()
        {
            // Het verbinden van de path die nodig om de locatie te vinden van de Excel worksheet (highscores.xlsx).
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string path = string.Format("{0}Resources\\highscores", System.IO.Path.GetFullPath(System.IO.Path.Combine(RunningPath, @"..\..\")));
            if (!File.Exists(path + "\\highscorestest.xls"))
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = xlWorkBook.Worksheets.get_Item(1);


                    xlWorkSheet.Cells[1, 1] = "ID";
                    xlWorkSheet.Cells[1, 2] = "Name";
                    xlWorkSheet.Cells[1, 3] = "Score";

                    xlWorkSheet.SaveAs(path + "\\highscorestest.xls");
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                }
            }
        }
    } 
