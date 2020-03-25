using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Weapons
{
    public abstract class Weapon
    {
        private const int DefaultWeaponLevel = 1;

        private int durability;

        private int attackPoints;

        private int level;

        protected Weapon()
        {
            this.Level = DefaultWeaponLevel;
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

        public void IncreaseLevel(int amount)
        {
            if (amount > 10)           
                //Some magic numbers are always needed
                throw new InvalidOperationException("Max weapon level is 10");
            

            if (amount <= 0)           
                throw new InvalidOperationException("Number must be bigger than 0");


            if (amount + this.Level >= 10)
            {
                this.Level = 10;
            }
            else
            {
                this.Level += amount;
            }

        }

        private void IncreaseAttackPoints(int level)
        {
            this.AttackPoints *= level;
        }
    }
}
