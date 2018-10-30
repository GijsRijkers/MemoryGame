using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{

    /// <summary>
    /// Interaction logic for Player.cs
    /// Objecten van andere classes worden meegegeven zodat deze gebruikt kunnen worden binnen deze class.
    /// </summary>
    public class Player
    {
        public String tempUserName;
        public double tempHighScore;

        /// <summary>
        /// Constructor van de Player class. 
        /// </summary>
        /// <param name="userName">De naam dat wordt ingevuld in de parameters.</param>
        /// <param name="highScore">De highscore dat wordt ingevuld in de parameters. </param>
        public Player(String userName, double highScore)
        {
            this.tempUserName = userName;
            this.tempHighScore = highScore;
        }

        /// <summary>
        /// Returned de naam van de speler.
        /// </summary>
        /// <returns></returns>
        public String getName()
        {
            return tempUserName.ToString();
        }

        /// <summary>
        /// Zet de highscore van een speler.
        /// </summary>
        /// <param name="value">De waarde die wordt ingevuld in de parameters.</param>
        /// <returns></returns>
        public double setHighScore(double value)
        {
            tempHighScore = value;
            return tempHighScore;
        }

        /// <summary>
        /// Returned de highScore van een speler.
        /// </summary>
        /// <returns></returns>
        public double getHighScore()
        {
            return tempHighScore;
        }
    }
}
