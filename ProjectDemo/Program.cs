using ProjectDemo.Controllers;
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

namespace ProjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Controller controller = new Controller();
            controller.Start();

        }
    }
}
