using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Fighters
{
    class Prisoner : Fighter
    {
        private const int PrisonerDefaultHealth = 10000;
        private const int PrisonerDefaultDefense = 0;

        public Prisoner(string name, Dice dice) 
            : base(name, dice)
        {
            this.Health = PrisonerDefaultHealth;
            this.MaxHealth = PrisonerDefaultHealth;
            this.Defense = PrisonerDefaultDefense;
        }
    }
}
