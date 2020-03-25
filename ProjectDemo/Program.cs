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
            Gladius gladius = new Gladius();

            Dice dice = new Dice(1000);
            Matador matador = new Matador("Pesho", dice);
            matador.TakeWeapon(gladius);

            Scientist scientist = new Scientist("Jhon", dice);

            SkyStage skyStage = new SkyStage(matador, scientist, dice, "FirstLevel");
            // fight
            skyStage.Fight();
            Console.ReadKey();

        }
    }
}
