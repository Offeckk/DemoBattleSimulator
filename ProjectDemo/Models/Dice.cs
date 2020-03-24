using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models
{
    public class Dice
    {
        private Random random;

        private int sidesCount;

        public Dice()
        {
            sidesCount = 6;
            random = new Random();
        }

        public Dice(int sidesCount)
        {
            this.sidesCount = sidesCount;
            random = new Random();
        }


        public int GetSidesCount()
        {
            return sidesCount;
        }


        public int Roll()
        {
            return random.Next(1, sidesCount + 1);
        }

        public override string ToString()
        {
            return String.Format("Dice with {0} sides", sidesCount);
        }
    }
}
