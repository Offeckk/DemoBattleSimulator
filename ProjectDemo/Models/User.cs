using ProjectDemo.Database;
using ProjectDemo.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            this.Battles = TakeBattlesData();
        }

        private int TakeBattlesData()
        {
            int result = 0;

            SqlConnection connection = new SqlConnection(Connection.CONNECTION_STRING);
            connection.Open();

            using (connection)
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Battles FROM Users WHERE Username = @username", connection
                    );

                cmd.Parameters.AddWithValue("@username", this.Username);

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    result = rd.GetInt32(0);
                }
            }

            return result;
        }

        public void AddBattle()
        {
            this.Battles += 1;
        }
    }
}
