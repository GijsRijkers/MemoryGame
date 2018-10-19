using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;




namespace Memory
{
    public class MemoryGrid
    {
        private Grid grid;

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            
            InitializeGameGrid(rows, cols);
            AddImages(rows, cols);
            
        }

        private void InitializeGameGrid(int cols, int rows)
        {
            for (int i  = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < rows; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

        }

        private void AddImages(int rows, int columns)
        {

            List<ImageSource> images = GetImagesList();
            for (int j = 0; j< rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("achterkant kaartjes.PNG", UriKind.Relative));
                    backgroundImage.Tag = images.First();
                    images.RemoveAt(0);
                    backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backgroundImage, i);
                    Grid.SetRow(backgroundImage, j);
                    grid.Children.Add(backgroundImage);
             
                }
            }
        }

        private List<ImageSource> GetImagesList()
        {
            List<ImageSource> images = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("pic" + imageNr + ".PNG", UriKind.Relative));
                
                images.Add(source);


            }
            //Hier moet de randomizer komen
            return images;

        }

        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
        }
    }
}
