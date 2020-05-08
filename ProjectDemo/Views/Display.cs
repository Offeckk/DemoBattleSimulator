using ProjectDemo.Models.Fighters;
using ProjectDemo.Models.Rooms;
using ProjectDemo.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Views
{
    public class Display
    {
        private const string InvalidStageMessage = "Please enter a valid stage type!";
        private const string InvalidWeaponMessage = "Please enter a valid weapon type!";
        private const string InvalidFighterMessage = "Please enter a valid fighter type!";
        private const string InvalidFighterNameMessage = "The fighter's name must be between 3 and 50 characters";

        private List<string> validWeapons;
        private List<string> validStages;
        private List<string> validFighters;

        public string StageType { get; set; }

        public string[] Fighters { get; set; }

        public string[] FightersName { get; set; }

        public List<String> FirstFighterWeapons { get; set; }

        public List<String> SecondFighterWeapons { get; set; }
        public List<string> ValidWeapons { get => validWeapons; private set => validWeapons = value; }
        public List<string> ValidStages { get => validStages; private set => validStages = value; }
        public List<string> ValidFighters { get => validFighters; private set => validFighters = value; }

        public Display()
        {
            ValidWeapons = new List<string>() { "longsword", "knife", "gladius", "angon" };
            ValidStages = new List<string>() { "skystage", "lavastage", "landstage", "icestage" };
            ValidFighters = new List<string>() { "warrior", "matador", "prisoner", "scientist" };
            GetValues();
        }

        private void GetValues()
        {
            Fighters = new string[2];
            FirstFighterWeapons = new List<string> { };
            SecondFighterWeapons = new List<string> { };
            FightersName = new string[2];

            //Taking stage-type
            TakeStage();

            //First fighter
            TakeFirstFighter();
            TakeFirstFighterWeapons();          


            //SEPERATOR
            Console.WriteLine();
            Console.WriteLine("Now its the second fighter's turn...");
            Console.WriteLine();

            //Second fighter
            TakeSecondFighter();
            TakeSecondFighterWeapons();

        }

        private void TakeFirstFighterWeapons()
        {
            Console.Write("Give the fighter some weapons: ");        

            FirstFighterWeapons = Console.ReadLine().Split(' ').Take(2).ToList();
            Console.WriteLine();

            while (!ValidateWeapons(FirstFighterWeapons))
            {
                Console.WriteLine(InvalidWeaponMessage);

                Console.Write("Give the fighter some weapons: ");
                FirstFighterWeapons = Console.ReadLine().Split(' ').Take(2).ToList();
                Console.WriteLine();
            }
        }

        private void TakeSecondFighterWeapons()
        {
            Console.Write("Give the fighter some weapons: ");

            SecondFighterWeapons = Console.ReadLine().Split(' ').Take(2).ToList();
            Console.WriteLine();

            while (!ValidateWeapons(SecondFighterWeapons))
            {
                Console.WriteLine(InvalidWeaponMessage);

                Console.Write("Give the fighter some weapons: ");
                SecondFighterWeapons = Console.ReadLine().Split(' ').Take(2).ToList();
                Console.WriteLine();
            }
        }

        private void TakeFirstFighter()
        {
            Console.Write("Please enter the type of the first fighter: ");

            Fighters[0] = Console.ReadLine();

            while (!ValidFighters.Contains(Fighters[0].ToLower()))
            {
                Console.WriteLine(InvalidFighterMessage);

                Console.Write("Please enter the type of the first fighter: ");
                Fighters[0] = Console.ReadLine();
                Console.WriteLine();
            }

            Console.Write("And his name is: ");
            FightersName[0] = Console.ReadLine();

            while (FightersName[0].Length < 3 || FightersName[0].Length > 50)
            {
                Console.WriteLine(InvalidFighterNameMessage);

                Console.Write("And his name is: ");
                FightersName[0] = Console.ReadLine();
                Console.WriteLine();
            }
        }

        private void TakeSecondFighter()
        {
            Console.Write("Please enter the type of the second fighter: ");

            Fighters[1] = Console.ReadLine();

            while (!ValidFighters.Contains(Fighters[1].ToLower()))
            {
                Console.WriteLine(InvalidFighterMessage);

                Console.Write("Please enter the type of the second fighter: ");
                Fighters[1] = Console.ReadLine();
                Console.WriteLine();
            }

            Console.Write("And his name is: ");
            FightersName[1] = Console.ReadLine();

            while (FightersName[1].Length < 3 || FightersName[1].Length > 50)
            {
                Console.WriteLine(InvalidFighterNameMessage);

                Console.Write("And his name is: ");
                FightersName[1] = Console.ReadLine();
                Console.WriteLine();
            }
        }
        
        private void TakeStage()
        {
        
            Console.Write("Please choose stage type: ");

            StageType = Console.ReadLine();

            while (!ValidStages.Contains(StageType.ToLower()))
            {
                Console.WriteLine(InvalidStageMessage);

                Console.Write("Please choose stage type: ");
                StageType = Console.ReadLine();
                Console.WriteLine();

            }
            Console.WriteLine();
        }

        private bool ValidateWeapons(List<string> weapons)
        {
            foreach (var weapon in weapons)
            {
                if (!ValidWeapons.Contains(weapon.ToLower()))
                {
                    return false;
                }
                
            }
            return true;
        }
    }
}
