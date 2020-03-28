using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjectDemo.Models.Fighters;

namespace ProjectDemo.Models.Rooms
{
    public class SkyStage : Arena
    {
        private const int SkyMatadorDefenseMultiplier = 3;
        private const int SkyWarriorHealthIncreaser = 3;
        private const int SkyPrisonerHealthDecreaser = 3;

        public SkyStage(Fighter warrior1, Fighter warrior2, Dice dice, string name) 
            : base(warrior1, warrior2, dice, name)
        {}

        public override void Fight()
        {
            Fighter[] fighters = new Fighter[2] { Fighter1, Fighter2 };

            ///TODO: Check fighter type and do the modifications
            foreach (var fighter in fighters)
            {
                if (fighter is Matador)
                {
                    fighter.Defense *= SkyMatadorDefenseMultiplier;
                    Console.WriteLine($"Matador {fighter.Name} multiplied his defense points by {SkyMatadorDefenseMultiplier}");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
                else if (fighter is Warrior)
                {
                    fighter.Health *= SkyWarriorHealthIncreaser;
                    Console.WriteLine($"Warrior {fighter.Name} multiplied his health {SkyWarriorHealthIncreaser} times");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }
                else if (fighter is Prisoner)
                {
                    fighter.Health /= SkyPrisonerHealthDecreaser;
                    Console.WriteLine($"The health of prisoner {fighter.Name} has been decreased {SkyPrisonerHealthDecreaser} times");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }

            }

            base.Fight();
        }
    }
}
