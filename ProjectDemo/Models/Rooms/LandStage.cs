using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDemo.Models.Fighters;

namespace ProjectDemo.Models.Rooms
{
    public class LandStage : Arena
    {
        private const int SecondWarriorWeaponAdvantage = 1;

        public LandStage(Fighter warrior1, Fighter warrior2, Dice dice, string name)
            : base(warrior1, warrior2, dice, name)
        {
        }

        public override void Fight()
        {
            Fighter[] fighters = new Fighter[2] { Warrior1, Warrior2 };

            if (Warrior2.Weapons.Count != 0)
            {
                Warrior2.Weapons.ForEach(w => w.IncreaseLevel(SecondWarriorWeaponAdvantage));
            }

            base.Fight();
        }
    }
}
