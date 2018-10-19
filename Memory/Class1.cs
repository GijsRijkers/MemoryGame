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
        //Verwijst naar de grid in het xaml file
        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            //Aanmaken van de grid
            InitializeGameGrid(rows, cols);
            //Plaatsen van de images op de aangegeven locatie
            AddImages(rows, cols);
            
        }

        private void InitializeGameGrid(int cols, int rows)
        {   //Zorgt ervoor dat het systeem de row herkent
            for (int i  = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            //Zorgt ervoor het systeem de column herkent
            for (int i = 0; i < rows; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

        }

       //Op iedere rij wordt plaats gemaakt voor een image met achtergrondplaatje
        private void AddImages(int rows, int columns)
        {

            List<ImageSource> images = GetImagesList();
            for (int j = 0; j< rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("achterkant kaartjes.PNG", UriKind.Relative));
                    //Door first haal je de eerste foto uit de GetImagesList lijst
                    backgroundImage.Tag = images.First();
                    //Door de eerste foto op locatie 0 te verwijderen, zorg je ervoor dat er steeds een nieuwe foto komt
                    images.RemoveAt(0);
                    //De background image een mouse button event geven
                    backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    //Plaatst de background image in de column op de door i bepaalde locatie
                    Grid.SetColumn(backgroundImage, i);
                    //Plaatst de background image in de rij op de door i bepaalde locatie
                    Grid.SetRow(backgroundImage, j);
                    //Voegt het plaatsen van de image toe
                    grid.Children.Add(backgroundImage);
             
                }
            }
        }

        //Hier wordt een list met 2x8 plaatjes gemaakt, deze worden aangeroepen door de berekening van imageNr Vervolgens wordt er 2x een source aan gekoppeld
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
        //Zorgt voor het meegeven van een nieuwe source en zorgt voor het omdraaien van het vraagteken
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
        }
    }
}
