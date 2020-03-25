using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProjectDemo.Models.Fighters;

namespace ProjectDemo.Models.Rooms
{
    public class LavaStage : Arena
    {

        private const int LavaDamageMultiplier = 2;
        private const int MatadorLavaWeaponIncreaser = 2;

        public LavaStage(Fighter warrior1, Fighter warrior2, Dice dice, string name)
            : base(warrior1, warrior2, dice, name)
        {}


        public override void Fight()
        {
            if (Warrior1.GetType() == typeof(Matador))
            {
                if (Warrior1.Weapons.Count == 0)
                {
                    Warrior1.Damage *= LavaDamageMultiplier;
                    Console.WriteLine($"The lava area multiplies the fist attack of {Warrior1.Name} by {LavaDamageMultiplier}");
                    Thread.Sleep(2000);
                }
                else
                {
                    foreach (var weapon in Warrior1.Weapons)
                    {
                        weapon.Level = MatadorLavaWeaponIncreaser;
                    }
                    Console.WriteLine($"The lava area increases the level of {Warrior1.Name}'s weapons by {MatadorLavaWeaponIncreaser}");
                    Thread.Sleep(2000);
                }
               
            }

            if (Warrior2.GetType() == typeof(Matador))
            {
                if (Warrior2.Weapons.Count == 0)
                {                   
                    Warrior1.Damage *= LavaDamageMultiplier;
                    Console.WriteLine($"The lava area multiplies the fist attack of {Warrior2.Name} by {LavaDamageMultiplier}");
                    Thread.Sleep(2000);
                }
                else
                {
                    foreach (var weapon in Warrior2.Weapons)
                    {                 
                        weapon.Level = MatadorLavaWeaponIncreaser;                   
                    }
                    Console.WriteLine($"The lava area increases the level of {Warrior2.Name}'s weapons by {MatadorLavaWeaponIncreaser}");
                    Thread.Sleep(2000);
                }

            }

            Console.WriteLine();

            base.Fight();

        }

    }
}

