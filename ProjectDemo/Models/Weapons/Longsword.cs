using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Weapons
{
    public class Longsword : Weapon
    {
        private const int DefaultLongswordAttackPoints = 900;
        private const int DefaultLongswordDurability = 300;

        public Longsword(int level)
            : base(level)
        {
            this.AttackPoints = DefaultLongswordAttackPoints;
            this.Durability = DefaultLongswordDurability;
        }

    }
}
