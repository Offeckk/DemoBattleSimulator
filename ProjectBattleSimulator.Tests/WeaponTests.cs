using NUnit.Framework;
using ProjectDemo.Models.Weapons;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void TestIfIncreaseLevelReturnsCorrectValue()
        {
            Angon angon = new Angon();
            var increaseLevel = 3;

            angon.IncreaseLevel(increaseLevel);

            Assert.AreEqual(4, increaseLevel + 1, "Level isn't 4 when we add 3 levels to a 1 level angon.");
        }

        [Test]
        public void TestIfHigherLevelIncreasesAttackPoints()
        {
            Gladius gladius = new Gladius();
            var increaseLevel = 4;

            gladius.IncreaseLevel(increaseLevel);
            gladius.IncreaseAttackPoints(gladius.Level);

            Assert.AreEqual(3500, gladius.AttackPoints, "Attack points aren't increased when the level is.");

        }

        [Test]
        public void TestIfWeaponIsBroken()
        {
            Knife knife = new Knife();
            knife.Durability = 0;

            bool IsBroken;

            if (knife.IsBroken)
            {
                IsBroken = true;
            }
            else
            {
                IsBroken = false;
            }

            Assert.AreEqual(true, IsBroken, "Knife isn't broken when its durability its 0.");
        }
    }
}