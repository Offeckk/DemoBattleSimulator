using ProjectDemo.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDemo.Models
{
    public class User
    {
        public string Username { get; private set; }

        public string Password { get; private set; }

        public int Battles { get; private set; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Battles = 0;
        }

        public void AddBattle()
        {
            this.Battles += 1;
        }
    }
}
