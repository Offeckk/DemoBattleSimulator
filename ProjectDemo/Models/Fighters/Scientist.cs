using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Fighters
{
    public class Scientist : Fighter
    {
        private const int ScientistHealthLosingAmount = 1000;
        private const int ScientistDefaultHealth = 3000;
        private const int ScientistDefaultDefense = 250;
        private const int ScientistDefaultHealthIncreasingNumber = 1000;

        //1 BY DEFAULT
        private int harmsCounter = 1;

        public Scientist(string name, Dice dice) 
            : base(name, dice)
        {
            this.Health = ScientistDefaultHealth;
            this.MaxHealth = ScientistDefaultHealth;
            this.Defense = ScientistDefaultDefense;
        }

        public int HarmsCounter { get => harmsCounter; set => harmsCounter = value; }

        public override void Defend(int hit)
        {            


            Dice scientistDice = new Dice(256);

            if (scientistDice.Roll() % 3 == 0)
            {
                hit = 0;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine((String.Format("Scientist {0} got his lucky number and parried the hit.", Name)));
                Thread.Sleep(2000);
                base.Defend(hit);
                Console.ForegroundColor = ConsoleColor.Black;
                
            }
            else if (scientistDice.Roll() % 7 == 0)
            {
                if (this.Health + ScientistDefaultHealthIncreasingNumber >= this.MaxHealth)
                {
                    this.Health = this.MaxHealth;
                }
                else
                {
                    this.Health += ScientistDefaultHealthIncreasingNumber;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine((String.Format("Scientist {0} got luck and himself with {1} health.",
                    Name, 
                    ScientistDefaultHealthIncreasingNumber)));
                Thread.Sleep(2000);
                base.Defend(hit);
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (scientistDice.Roll() % 9 == 0)
            {
                this.Health -= ScientistHealthLosingAmount * this.HarmsCounter;
                this.HarmsCounter += 1;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(String.Format("Scientist {0} was unlucky and harmed himself with {1} extra damage"
                    , Name
                    , ScientistHealthLosingAmount * (HarmsCounter - 1)));
                Thread.Sleep(2000);
                base.Defend(hit);
                Console.ForegroundColor = ConsoleColor.Black;              
            }
            else
            {
                base.Defend(hit);
            }

            
        }
    }
}
