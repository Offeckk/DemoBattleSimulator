using ProjectDemo.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Rooms
{
    public abstract class Stage
    {
        private string name;

        private Fighter fighter1;
 
        private Fighter fighter2;

        private Dice dice;

        public Fighter Fighter1 { get => fighter1; set => fighter1 = value; }
        public Fighter Fighter2 { get => fighter2; set => fighter2 = value; }
        public Dice Dice { get => dice; set => dice = value; }
        public string Name { get => name; set => name = value; }

        public Stage(Fighter fighter1, Fighter fighter2, Dice dice)
        {
            this.Fighter1 = fighter1;
            this.Fighter2 = fighter2;
            this.Dice = dice;
        }

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
            Console.WriteLine($"{this.Name}");
            Console.WriteLine("Fighters: \n");
            PrintWarrior(Fighter1);
            Console.WriteLine();
            PrintWarrior(Fighter2);
            Console.WriteLine();
        }


        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(500);
        }

        public virtual void Fight()
        {
            // The original fighters order
            Fighter f1 = Fighter1;
            Fighter f2 = Fighter2;
            Console.WriteLine();
            Console.WriteLine("Welcome to Stage!");
            Console.WriteLine("Today {0} will fight with {1}! \n", Fighter1.Name, Fighter2.Name);

            // swapping the fighers
            bool fighter2Starts = (Dice.Roll() <= Dice.GetSidesCount() / 2);
            if (fighter2Starts)
            {
                f1 = Fighter2;
                f2 = Fighter1;
            }
            Console.WriteLine("The fighter {0} begins! \nLet the battle begin...", f1);
            Console.ReadKey();

            // fight loop
            while (f1.Alive() && f2.Alive())
            {
                f1.Attack(f2);
                Render();
                PrintMessage(f1.GetLastMessage()); // message about the attack
                PrintMessage(f2.GetLastMessage()); // message about the defense                
                if (f2.Alive())
                {
                    f2.Attack(f1);
                    Render();
                    PrintMessage(f2.GetLastMessage()); // message about the attack
                    PrintMessage(f1.GetLastMessage()); // message about the defense
                }
                Console.WriteLine();
            }
        }
    }
}
