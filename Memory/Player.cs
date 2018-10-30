using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class Player
    {
        public String tempUserName;
        public double tempHighScore;

        public Player(String userName, double highScore)
        {
            this.tempUserName = userName;
            this.tempHighScore = highScore;
        }

        public String getName()
        {
            return tempUserName.ToString();
        }

        public double setHighScore(double value)
        {
            tempHighScore = value;
            return tempHighScore;
        }
        public double getHighScore()
        {
            return tempHighScore;
        }
    }
}
