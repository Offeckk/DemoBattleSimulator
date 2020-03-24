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
        private const int ScientistHealthLosingAmount = 400;
        private const int ScientistDefaultHealth = 3000;
        private const int ScientistDefaultDefense = 250;

        public Scientist(string name, Dice dice) 
            : base(name, dice)
        {
            this.Health = ScientistDefaultHealth;
            this.MaxHealth = ScientistDefaultHealth;
            this.Defense = ScientistDefaultDefense;
        }

        public override void Defend(int hit)
        {            

            Dice scientistDice = new Dice(this.Name.Length * 10);

            if (scientistDice.Roll() % 2 == 0)
            {
                base.Defend(hit);
            }
            else if (scientistDice.Roll() % 3 == 0)
            {
                this.MaxHealth *= 3;
                this.Health = MaxHealth;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine((String.Format("Scientist {0} got luck and multiplied his health 3 times.", Name)));
                Thread.Sleep(2000);
                base.Defend(hit);
            }
            else if (scientistDice.Roll() == this.Name.Length)
            {
                hit = 0;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine((String.Format("Scientist {0} got his lucky number and parried the hit.", Name)));
                Thread.Sleep(2000);
                base.Defend(hit);
            }
            else
            {
                this.Health -= ScientistHealthLosingAmount;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(String.Format("Scientist {0} was unlucky and harmed himself with {1} extra damage"
                    ,Name 
                    ,ScientistHealthLosingAmount));
                Thread.Sleep(2000);
                base.Defend(hit);
            }

            
        }
    }
}
