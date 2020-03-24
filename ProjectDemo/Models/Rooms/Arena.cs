using ProjectDemo.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Rooms
{
    class Arena
    {

        private Fighter warrior1;
 
        private Fighter warrior2;

        private Dice dice;
   
        public Arena(Fighter warrior1, Fighter warrior2, Dice dice)
        {
            this.warrior1 = warrior1;
            this.warrior2 = warrior2;
            this.dice = dice;
        }

        /// <summary>
        /// Prints warrior info
        /// </summary>
        /// <param name="f">Warrior instance</param>
        private void PrintWarrior(Fighter f)
        {
            Console.WriteLine(f);
            Console.Write("Health:  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(f.HealthBar());
            Console.ResetColor();
            if (f is Matador)
            {
                Console.Write("Stamina: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(((Matador)f).StaminaBar());
                Console.ResetColor();
            }
        }


        private void Render()
        {
            Console.Clear();
            Console.WriteLine(@"
            ______ _          _     _                    _ 
            |  ___(_)        | |   | |                  | |
            | |_   _ _ __ ___| |_  | |     _____   _____| |
            |  _| | | '__/ __| __| | |    / _ \ \ / / _ \ |
            | |   | | |  \__ \ |_  | |___|  __/\ V /  __/ |
            \_|   |_|_|  |___/\__| \_____/\___| \_/ \___|_|                                              
                                               ");
            Console.WriteLine("Warriors: \n");
            PrintWarrior(warrior1);
            Console.WriteLine();
            PrintWarrior(warrior2);
            Console.WriteLine();
        }


        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(500);
        }


        public void Fight()
        {
            // The original warriors order
            Fighter w1 = warrior1;
            Fighter w2 = warrior2;
            Console.WriteLine("Welcome to Arena!");
            Console.WriteLine("Today {0} will fight with {1}! \n", warrior1, warrior2);
            // swapping the warriors
            bool warrior2Starts = (dice.Roll() <= dice.GetSidesCount() / 2);
            if (warrior2Starts)
            {
                w1 = warrior2;
                w2 = warrior1;
            }
            Console.WriteLine("The warrior {0} begins! \nLet the battle begin...", w1);
            Console.ReadKey();
            // fight loop
            while (w1.Alive() && w2.Alive())
            {
                w1.Attack(w2);
                Render();
                PrintMessage(w1.GetLastMessage()); // message about the attack
                PrintMessage(w2.GetLastMessage()); // message about the defense                
                if (w2.Alive())
                {
                    w2.Attack(w1);
                    Render();
                    PrintMessage(w2.GetLastMessage()); // message about the attack
                    PrintMessage(w1.GetLastMessage()); // message about the defense
                }
                Console.WriteLine();
            }
        }
    }
}
