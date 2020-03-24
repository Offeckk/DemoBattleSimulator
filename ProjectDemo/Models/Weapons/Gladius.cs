using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Weapons
{
    public class Gladius : Weapon
    {
        private const int DefaultGladiusAttackPoints = 700;
        private const int DefaultGladiusDurability = 250;

        public Gladius(int level)
            : base(level)
        {
            this.AttackPoints = DefaultGladiusAttackPoints;
            this.Durability = DefaultGladiusDurability;
        }
    }
}
