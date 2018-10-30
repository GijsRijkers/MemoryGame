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


        //MemoryGrid ResetGrid;

        public MainWindow()
        {
            InitializeComponent();
            getWorkSheet();
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

        private void getWorkSheet()
        {
            // Het verbinden van de path die nodig om de locatie te vinden van de Excel worksheet (highscores.xlsx).
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string path = string.Format("{0}Resources\\highscores", System.IO.Path.GetFullPath(System.IO.Path.Combine(RunningPath, @"..\..\")));
            if (!File.Exists(path))
            {
                    Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells[1, 1] = "ID";
                    xlWorkSheet.Cells[1, 2] = "Name";
                    xlWorkSheet.Cells[1, 2] = "Score";

                    xlWorkBook.SaveAs(path + "\\highscores.xls", FileFormat: Excel.XlFileFormat.xlWorkbookNormal, Password: misValue, WriteResPassword: misValue, ReadOnlyRecommended: misValue, CreateBackup: misValue, AccessMode: Excel.XlSaveAsAccessMode.xlExclusive, ConflictResolution: misValue, AddToMru: misValue, TextCodepage: misValue, TextVisualLayout: misValue, Local: misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                }
            }
        }
    } 
