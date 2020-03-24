using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models.Fighters
{
    public class Matador : Fighter
    {
        private const int MatadorDefaultHealth = 5000;
        private const int MatadorDefaultDefense = 100;

        private int stamina;

        private int maxStamina;

        private int heavyDamage;

        public Matador(string name, Dice dice, int stamina, int heavyDamage)
            : base(name, dice)
        {

            this.Health = MatadorDefaultHealth;
            this.MaxHealth = MatadorDefaultHealth;
            this.Defense = MatadorDefaultDefense;
            this.stamina = stamina;
            this.maxStamina = stamina;
            this.heavyDamage = heavyDamage;
        }

        public override void Attack(Fighter enemy)
        {
            // Stamina is not full
            if (stamina < maxStamina)
            {
                stamina += 30;
                if (stamina > maxStamina)
                    stamina = maxStamina;
                base.Attack(enemy);
            }
            else // Heavy damage
            {
                int hit = heavyDamage + Dice.Roll();
                SetMessage(String.Format("{0} attacked {1} hp with heavy power", Name, hit));
                enemy.Defend(hit);
                stamina = 0;
            }
        }

        public string StaminaBar()
        {
            return GraphicalBar(stamina, maxStamina);
        }
    }
}
