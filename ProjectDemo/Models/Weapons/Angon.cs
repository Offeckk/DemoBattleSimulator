using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Weapons
{
    public class Angon : Weapon
    {
        private const int DefaultAngonAttackPoints = 850;
        private const int DefaultAngonDurability = 200;

        public Angon(int level)
            : base(level)
        {
            this.AttackPoints = DefaultAngonAttackPoints;
            this.Durability = DefaultAngonDurability;
        }
    }
}
