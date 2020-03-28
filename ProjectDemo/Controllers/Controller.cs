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
        private Display display;
        private Arena stage;
        private Fighter[] fighters;
        private List<Weapon> firstFigherWeapons;
        private List<Weapon> secondFigherWeapons;

        public Controller()
        {
            display = new Display();

            fighters = new Fighter[2];
            firstFigherWeapons = new List<Weapon>();
            secondFigherWeapons = new List<Weapon>();
        }

        public void Start()
        {
            //Dice with sides equal to 25% of lowest Figther Type health
            Dice dice = new Dice(750);

            Type stageType = Type.GetType(display.StageType);
            object a = Activator.CreateInstance(stageType);
            stage = (Arena)a;

            //FirstFighter
            string firstFighterName = display.FightersName[0];
            Type firstFighterType = Type.GetType(display.Fighters[0]);
            object f1 = Activator.CreateInstance(firstFighterType);
            this.fighters[0] = (Fighter)f1;

            
            //SecondFighter
            string secondFighterName = display.FightersName[1];
            Type secondFighterType = Type.GetType(display.Fighters[1]);
            object f2 = Activator.CreateInstance(secondFighterType);
            this.fighters[1] = (Fighter)f2;

            stage.Dice = dice;
            stage.Fighter1 = fighters[0];
            stage.Fighter2 = fighters[1];

            //TODO add weapons to fighters

        }

    }
}
