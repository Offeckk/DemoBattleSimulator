using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectDemo.Models.Fighters;

namespace ProjectDemo.Models.Rooms
{
    public class IceStage : Stage
    {
        private const int IceMatadorWeaponIncreaser = 2;
        private const int IceMatadorHealthDecreaser = 2;
        private const int IceWarriorHealthIncreaser = 2;
        private const int IceWarriorWeaponIncreaser = 3;
        private const int IcePrisonerHealthIncreaser = 3;
        private const int IcePrisonerDefenseIncreaser = 3;
        private const int IceScientistDefenseIncreaser = 4;



        public IceStage(Fighter warrior1, Fighter warrior2, Dice dice) 
            : base(warrior1, warrior2, dice)
        {
        }

        public override void Fight()
        {
            Fighter[] fighters = new Fighter[2] { Fighter1, Fighter2 };

            ///TODO: Check fighter type and do the modifications
            foreach (var fighter in fighters)
            {
                if (fighter is Matador)
                {
                    fighter.Weapons.ForEach(w => w.IncreaseLevel(IceMatadorWeaponIncreaser));
                    fighter.MaxHealth /= IceMatadorHealthDecreaser;
                    fighter.Health = fighter.MaxHealth;
                }
                else if (fighter is Warrior)
                {
                    fighter.Weapons.ForEach(w => w.IncreaseLevel(IceWarriorWeaponIncreaser));
                    fighter.MaxHealth /= IceWarriorHealthIncreaser;
                    fighter.Health = fighter.MaxHealth;
                }
                else if (fighter is Prisoner)
                {
                    fighter.MaxHealth *= IcePrisonerHealthIncreaser;
                    fighter.Health = fighter.MaxHealth;
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
