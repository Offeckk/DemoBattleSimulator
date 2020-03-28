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
        public string StageType { get; set; }

        public string[] Fighters { get; set; }

        public string[] FightersName { get; set; }

        public List<String> FirstFighterWeapons { get; set; }

        public List<String> SecondFighterWeapons { get; set; }

        public Display()
        {
            GetValues();
        }

        private void GetValues()
        {
            Fighters = new string[2];
            FirstFighterWeapons = new List<string> { };
            SecondFighterWeapons = new List<string> { };
            FightersName = new string[2];


            Console.Write("Please choose stage type: ");
            StageType = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();

            //First fighter
            Console.Write("Please enter the type of the first fighter: ");
            Fighters[0] = Console.ReadLine();

            Console.Write("And his name is: ");
            FightersName[0] = Console.ReadLine();

            Console.Write("Does he have some weapons or just his fist: ");
            FirstFighterWeapons = Console.ReadLine().Split(' ').ToList();

            //SEPERATOR
            Console.WriteLine();
            Console.WriteLine("Now its the second fighter's turn...");
            Console.WriteLine();

            //Second fighter
            Console.Write("Please enter the type of the second fighter: ");
            Fighters[1] = Console.ReadLine();

            Console.Write("And his name is: ");
            FightersName[1] = Console.ReadLine();

            Console.Write("Does he have some weapons or just his fist: ");
            SecondFighterWeapons = Console.ReadLine().Split(' ').ToList();


        }
    }
}
