using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Fighters
{
    public class Warrior : Fighter
    {
        private const int WarriorDefaultHealth = 7000;
        private const int WarriorDefaultDefense = 200;

        public Warrior(string name, Dice dice)
            : base(name, dice)
        {
            this.Health = WarriorDefaultHealth;
            this.MaxHealth = WarriorDefaultHealth;
            this.Defense = WarriorDefaultDefense;
        }


    }
}
