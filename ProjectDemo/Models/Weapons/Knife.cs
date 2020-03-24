using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int DefaultKnifeAttackPoints = 375;
        private const int DefaultKnifeDurability = 250;

        public Knife(int level) 
            : base(level)
        {
            this.AttackPoints = DefaultKnifeAttackPoints;
            this.Durability = DefaultKnifeDurability;
        }
    }
}
