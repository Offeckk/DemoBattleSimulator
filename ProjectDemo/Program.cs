using ProjectDemo.Models;
using ProjectDemo.Models.Fighters;
using ProjectDemo.Models.Rooms;
using ProjectDemo.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Gladius gladius = new Gladius(1);

            Dice dice = new Dice(1000);
            Warrior warrior = new Warrior("Pesho", dice);
            warrior.TakeWeapon(gladius);

            Scientist scientist = new Scientist("Jhon", dice);

            Arena arena = new Arena(warrior, scientist, dice);
            // fight
            arena.Fight();
            Console.ReadKey();

        }
    }
}
