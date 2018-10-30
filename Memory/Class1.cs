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
        private int cols;
        private int rows;

        private Image card1 = null;
        private Image card2 = null;

        private Grid grid;
        private List<Tuple<string, ImageSource>> imageSources;
        private List<string> matchedImageList = new List<string>();

        private bool handsfull = false;

        private bool hasWon = false;
        private Singleplayer singlePlayer = null;
        private int score;

        //Verwijst naar de grid in het xaml file
        public MemoryGrid(Grid grid, int cols, int rows, Singleplayer singlePlayer)
        {
            this.cols = cols;
            this.rows = rows;

            this.grid = grid;

            this.score = 0;
            this.singlePlayer = singlePlayer;

            imageSources = GetImagesList();

            //Aanmaken van de grid
            InitializeGameGrid();
            
            //Plaatsen van de images op de aangegeven locatie
            AddImages();
        }

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.cols = cols;
            this.rows = rows;

            this.grid = grid;

            this.score = 0;

            imageSources = GetImagesList();

            //Aanmaken van de grid
            InitializeGameGrid();

            //Plaatsen van de images op de aangegeven locatie
            AddImages();
        }


        private void InitializeGameGrid()
        {   
            //Zorgt ervoor dat het systeem de row herkent
            for (int i = 0; i < this.rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            //Zorgt ervoor het systeem de column herkent
            for (int i = 0; i < this.rows; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

        }

        //Op iedere rij wordt plaats gemaakt voor een image met achtergrondplaatje
        private void AddImages()
        {
            List<Tuple<string, ImageSource>> images = imageSources;
            int count = 0;
            for (int j = 0; j < this.rows; j++)
            {
                for (int i = 0; i < this.cols; i++)
                {
                    string foundMatch = matchedImageList.FirstOrDefault(x => x == images[count].Item1);

                    // Geen match gevonden, dus deze memory heb je nog niet
                    if (foundMatch == null)
                    {
                        //Door first haal je de eerste foto uit de GetImagesList lijst
                        //De background image een mouse button event geven
                        //Plaatst de background image in de column op de door i bepaalde locatie
                        Image backgroundImage = new Image
                        {
                            Source = new BitmapImage(new Uri("achterkant kaartjes.PNG", UriKind.Relative)),
                            Tag = images[count].Item2,
                            Uid = images[count].Item1
                        };
                        backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);


                        Grid.SetColumn(backgroundImage, i);
                        //Plaatst de background image in de rij op de door i bepaalde locatie
                        Grid.SetRow(backgroundImage, j);
                        //Voegt het plaatsen van de image toe
                        grid.Children.Add(backgroundImage);
                    }
                    count++;
                }
            }
        }

        internal static void handsFull()
        {
            throw new NotImplementedException();
        }

        //Hier wordt een list met 2x8 plaatjes gemaakt, deze worden aangeroepen door de berekening van imageNr Vervolgens wordt er 2x een source aan gekoppeld
        private List<Tuple<string, ImageSource>> GetImagesList()
        {
            List<Tuple<string, ImageSource>> images = new List<Tuple<string, ImageSource>>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("pic" + imageNr + ".PNG", UriKind.Relative));

                images.Add(Tuple.Create(imageNr.ToString(), source));
            }
            //Hier moet de randomizer komen
            return Shuffle(images);
        }

        //Zorgt voor het meegeven van een nieuwe source en zorgt voor het omdraaien van de vraagteken
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            
            if (handsfull)
            {
                handsfull = false;
                ResetGrid();
                return;
            }
            
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
            // Pak kaart 2
            if (card1 != null && card2 == null)
            {
                this.card2 = (Image)sender;
            }
            //Pak kaart 1
            else
            {
                this.card1 = (Image)sender;
            }

            if (card1 != null && card2 != null)
            {
                var x = card1;
                if (card1.Uid == card2.Uid)
                {
                    matchedImageList.Add(card1.Uid);
                    handsfull = true;

                    score += 10;
                }
                else
                {
                    handsfull = true;
                    score -= 1;
                }
            }
            singlePlayer?.showScore();
        }

        public void ResetGrid()
        {
            card1 = null;
            card2 = null;
            this.grid.Children.Clear();
            AddImages();
        }
        
        //De functie zorgt voor het randomizen van de eerder aangemaakte list met daarin de source, tag en klik-functie
        private List<Tuple<string, ImageSource>> Shuffle(List<Tuple<string,ImageSource>> imageList)
        {
            Random randomizer = new Random();
            int n = imageList.Count;
            while (n > 1)
            {
                n--;
                int k = randomizer.Next(n + 1);
                Tuple<string, ImageSource> value = imageList[k];
                imageList[k] = imageList[n];
                imageList[n] = value;
            }
            return imageList;
        }

       
        public int getImageCount()
        {
            return matchedImageList.Count;
        }

        public void setWin()
        {
            hasWon = true;
        }

        public int getScore()
        {
            return score;
        }
    }
}
