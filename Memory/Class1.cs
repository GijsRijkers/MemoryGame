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
    /// <summary>
    /// Hier is de class die zorgt voor het aanmaken van de columns en rows zodat er een image geprint kan worden op de gecreëerde locaties.
    /// </summary>
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
        private SingleplayerEasy singleplayerEasy = null;
        private int score;

        public Player uPlayer;
        public SinglePlayerNameSelect singlePlayerWin;

        /// <summary>
        /// Verwijst naar de parameters hieronder in de grid voor singlePlayer
        /// </summary>
        /// <param name="grid">Is het speelveld</param>
        /// <param name="cols">Zijn de verticale rijen</param>
        /// <param name="rows">Zijn de horizontale rijen</param>
        /// <param name="singlePlayer">Verwijst naar het singleplayerscherm</param>

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

        /// <summary>
        /// Verwijst naar de parameters hieronder in de grid
        /// </summary>
        /// <param name="grid">Is het speelveld</param>
        /// <param name="cols">Zijn de verticale rijen</param>
        /// <param name="rows">Zijn de horizontale rijen</param>
        public MemoryGrid(Grid grid, int cols, int rows, SingleplayerEasy singlePlayerEasy)
        {
            this.cols = cols;
            this.rows = rows;

            this.grid = grid;

            this.score = 0;
            this.singleplayerEasy = singleplayerEasy;

            imageSources = GetImagesList();

            //Aanmaken van de grid
            InitializeGameGrid();

            //Plaatsen van de images op de aangegeven locatie
            AddImages();
        }

        public void setPlayer(Player player) { uPlayer = player; }

        /// <summary>
        /// Zorgt voor het herkennen van de row en column
        /// </summary>
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
        
        /// <summary>
        /// Hier wordt de grid gemaakt, 4x per horizontale rij worden er ook 4 verticale rijen gemaakt. Dit zorgt voor de grid
        /// </summary>
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
        /// <summary>
        /// Tuple is als een dictionary alleen is het in runtime niet mogelijk deze waardes aan te passen. In deze tuple
        /// wordt er 8x een source van de plaatjes gekozen 
        /// </summary>
        /// <returns>Returned de kaarten die door de randomizer geweest zijn</returns>
        
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

        /// <summary>
        /// Zorgt voor het meegeven van een nieuwe source en zorgt voor het omdraaien van de vraagteken
        /// </summary>
        /// <param name="sender">Sender is in dit geval de klik en is gekoppeld aan de PNG van de achterkant kaartjes</param>

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
            card.IsEnabled = false;
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

            // Als SinglePlayer bestaat, laat de score zien.
            if (singlePlayer != null)
            {
                singlePlayer?.showScore();
            }

            if (singleplayerEasy != null)
            {
                singleplayerEasy?.showScore();
            }

        }

        /// <summary>
        /// Zorgt voor het resetten van de grid zodat alle kaarten weer terug komen
        /// </summary>
        public void ResetGrid()
        {
            card1 = null;
            card2 = null;
            this.grid.Children.Clear();
            AddImages();
        }

        /// <summary>
        /// De functie zorgt voor het randomizen van de eerder aangemaakte list met daarin de source, tag en klik-functie
        /// </summary>
        /// <param name="imageList"></param>
        /// <returns>Returned een geshuffelde imageList</returns>
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

        /// <summary>
        /// Telt het aantal gematchte kaarten in de nieuwe matchedImageList
        /// </summary>
        /// <returns>Het aantal dat geteld is</returns>
        public int getImageCount()
        {
            return matchedImageList.Count;
        }

        /// <summary>
        /// Zet de haswon bool op true
        /// </summary>
        public void setWin()
        {
            hasWon = true;
        }

        /// <summary>
        /// returned de score
        /// </summary>
        public int getScore()
        {
            return score;
        }
    }
}
