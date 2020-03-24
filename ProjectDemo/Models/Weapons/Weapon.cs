using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Weapons
{
    public abstract class Weapon
    {
        private int durability;

        private int attackPoints;

        private int level;

        protected Weapon(int level)
        {
            this.Level = level;
        }

        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            set
            {
                this.attackPoints = value;
            }
        }

        public int Durability
        {
            get { return this.durability; }
            set { this.durability = value; }
        }

        public bool IsBroken => this.Durability <= 0;

        public bool IsTaken = false;

        public void DecreaseDurability(int amount)
        {
            if (this.IsBroken)
            {
                throw new InvalidOperationException("The weapon is broken.");
            }

            if (amount >= this.Durability)
            {
                this.Durability = 0;
            }
            else
            {
                this.Durability -= amount;
            }
        }


    }
}
