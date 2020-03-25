using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDemo.Models.Fighters;

namespace ProjectDemo.Models.Rooms
{
    public class IceStage : Arena
    {
        private const int IceMatadorWeaponIncreaser = 2;
        private const int IceMatadorHealthDecreaser = 2;
        private const int IceWarriorHealthIncreaser = 2;
        private const int IceWarriorWeaponIncreaser = 3;
        private const int IcePrisonerHealthIncreaser = 3;
        private const int IcePrisonerDefenseIncreaser = 3;
        private const int IceScientistDefenseIncreaser = 10;



        public IceStage(Fighter warrior1, Fighter warrior2, Dice dice, string name) 
            : base(warrior1, warrior2, dice, name)
        {
        }

        public override void Fight()
        {
            Fighter[] fighters = new Fighter[2] { Warrior1, Warrior2 };

            ///TODO: Check fighter type and do the modifications
            foreach (var fighter in fighters)
            {
                if (fighter is Matador)
                {
                    fighter.Weapons.ForEach(w => w.IncreaseLevel(IceMatadorWeaponIncreaser));
                    fighter.Health /= IceMatadorHealthDecreaser;
                }
                else if (fighter is Warrior)
                {
                    fighter.Weapons.ForEach(w => w.IncreaseLevel(IceWarriorWeaponIncreaser));
                    fighter.Health /= IceWarriorHealthIncreaser;
                }
                else if (fighter is Prisoner)
                {
                    fighter.Health *= IcePrisonerHealthIncreaser;
                    fighter.Defense *= IcePrisonerDefenseIncreaser;
                }
                else if (fighter is Scientist)
                {
                    fighter.Defense *= IceScientistDefenseIncreaser;
                }
            }

            base.Fight();
        }
    }
}
