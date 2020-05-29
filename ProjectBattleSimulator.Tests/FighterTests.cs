using System;
using NUnit.Framework;
using ProjectDemo.Models.Weapons;
using ProjectDemo.Models.Fighters;
using ProjectDemo.Models;

namespace Tests
{
    public class FighterTests
    {
        [Test]
        public void CheckIfFighterWithNullOrWhitespaceNameThrowsException()
        {
            string message = "";
            Dice dice = new Dice(100);

            try
            {
                Warrior warrior = new Warrior(null, dice);
            }
            catch (ArgumentException ae)
            {

                message = ae.Message;
            }

            Assert.AreEqual("Name cannot be null or white space!", message, "Fighter does not throw exception when initialized with null or whitespace name");
        }

        [Test]
        public void ChechIfFighterIsAliveWhenItsHealthIsLowerThanZero()
        {
            Prisoner prisoner = new Prisoner("Pesho", new Dice(300));
            prisoner.Health = 0;

            bool IsAlive;

            if (prisoner.Alive() == false)
            {
                IsAlive = false;
            }
            else
            {
                IsAlive = true;
            }

            Assert.AreEqual(false, IsAlive, "Fighter is not dead when its health is zero.");
        }

        [Test]
        public void CheckIfFighterTakesDamage()
        {
            Matador matador = new Matador("Ivan", new Dice(300));


            matador.Defend(1000);

            var result = matador.Health;

            Assert.AreNotEqual(5000, result, "Fighter does not take damage when it's attacked");
        }
    }
}