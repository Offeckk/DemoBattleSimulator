using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDemo.Models.Fighters;

namespace ProjectDemo.Models.Rooms
{
    public class LandStage : Stage
    {
        private const int SecondWarriorWeaponAdvantage = 1;

        public LandStage(Fighter fighter1, Fighter fighter2, Dice dice)
            : base(fighter1, fighter2, dice)
        {
        }

        public override void Fight()
        {
            base.Fight();
        }
    }
}
