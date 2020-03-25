using ProjectDemo.Models.Fighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Rooms
{
    public abstract class Arena
    {
        private string name;

        private Fighter warrior1;
 
        private Fighter warrior2;

        private Dice dice;

        public Fighter Warrior1 { get => warrior1; set => warrior1 = value; }
        public Fighter Warrior2 { get => warrior2; set => warrior2 = value; }
        public Dice Dice { get => dice; set => dice = value; }
        public string Name { get => name; set => name = value; }

        public Arena(Fighter warrior1, Fighter warrior2, Dice dice, string name)
        {
            this.Warrior1 = warrior1;
            this.Warrior2 = warrior2;
            this.Dice = dice;
            this.Name = name;
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
            Console.WriteLine("Warriors: \n");
            PrintWarrior(Warrior1);
            Console.WriteLine();
            PrintWarrior(Warrior2);
            Console.WriteLine();
        }


        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(500);
        }

        public virtual void Fight()
        {
            // The original warriors order
            Fighter w1 = Warrior1;
            Fighter w2 = Warrior2;
            Console.WriteLine("Welcome to Arena!");
            Console.WriteLine("Today {0} will fight with {1}! \n", Warrior1, Warrior2);
            // swapping the warriors
            bool warrior2Starts = (Dice.Roll() <= Dice.GetSidesCount() / 2);
            if (warrior2Starts)
            {
                w1 = Warrior2;
                w2 = Warrior1;
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
