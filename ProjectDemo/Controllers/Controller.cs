using ProjectDemo.Models;
using ProjectDemo.Models.Fighters;
using ProjectDemo.Models.Rooms;
using ProjectDemo.Models.Weapons;
using ProjectDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Controllers
{
    public class Controller
    {
        private Dice dice;
        private Display display;
        private Stage stage;
        private Fighter[] fighters;
        private List<string> firstFigherWeapons;
        private List<string> secondFigherWeapons;

        public Controller()
        {
            display = new Display();

            fighters = new Fighter[2];
            firstFigherWeapons = display.FirstFighterWeapons;
            secondFigherWeapons = display.SecondFighterWeapons;
        }

        //Dice with sides equal to 25% of lowest Figther Type health
        public Dice Dice { get => dice = new Dice(750); }
        public Stage Stage { get => stage; private set => stage = value; }

        public void Start()
        {

            //FirstFighter
            string firstFighterName = display.FightersName[0];
            string firstFighterType = display.Fighters[0];
            this.fighters[0] = SummonFighter(firstFighterType, firstFighterName);


            //SecondFighter
            string secondFighterName = display.FightersName[1];
            string secondFighterType = display.Fighters[1];
            this.fighters[1] = SummonFighter(secondFighterType, secondFighterName);

            //1st fighter
            foreach (var weapon in firstFigherWeapons)
            {
                try
                {
                    fighters[0].TakeWeapon(ToWeapon(weapon));
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e);
                }
            }
            //2nd fighter

            foreach (var weapon in secondFigherWeapons)
            {
                try
                {
                    fighters[1].TakeWeapon(ToWeapon(weapon));
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e);
                }
            }


            //Create stage
            var fighter1 = fighters[0];
            var fighter2 = fighters[1];
            try
            {
                var tempStage = CreateStage(display.StageType, fighter1, fighter2);
                Stage = tempStage;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }

            Stage.Fight();

        }

        private dynamic CreateStage(string stageType, Fighter fighter1, Fighter fighter2)
        {
            switch (stageType.ToLower())
            {
                case "icestage":
                    {
                        IceStage iceStage = new IceStage(fighter1, fighter2, Dice);
                        return iceStage;
                    }

                case "landstage":
                    {
                        LandStage landStage = new LandStage(fighter1, fighter2, Dice);
                        return landStage;
                    }

                case "lavastage":
                    {
                        LavaStage lavaStage = new LavaStage(fighter1, fighter2, Dice);
                        return lavaStage;
                    }

                case "skystage":
                    {
                        SkyStage skyStage = new SkyStage(fighter1, fighter2, Dice);
                        return skyStage;
                    }

                default:
                    return null;
            }
        }

        private dynamic SummonFighter(string fighterType, string fighterName)
        {
            switch (fighterType.ToLower())
            {
                case "warrior":
                    {
                        Warrior warrior = new Warrior(fighterName, Dice);
                        return warrior;
                    }

                case "scientist":
                    {
                        Scientist scientist = new Scientist(fighterName, Dice);
                        return scientist;
                    }

                case "prisoner":
                    {
                        Prisoner prisoner = new Prisoner(fighterName, Dice);
                        return prisoner;
                    }

                case "matador":
                    {
                        Matador matador = new Matador(fighterName, Dice);
                        return matador;
                    }
                default:
                    return null;
            }
        }

        private dynamic ToWeapon(string weaponType)
        {
            switch (weaponType.ToLower())
            {
                case "longsword":
                    {
                        Longsword longsword = new Longsword();
                        return longsword;
                    }

                case "knife":
                    {
                        Knife knife = new Knife();
                        return knife;
                    }

                case "gladius":
                    {
                        Gladius gladius = new Gladius();
                        return gladius;
                    }

                case "angon":
                    {
                        Angon angon = new Angon();
                        return angon;
                    }
                default:
                    return null;

            }

        }


    }
}
