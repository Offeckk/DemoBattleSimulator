using ProjectDemo.Database;
using ProjectDemo.Models.Fighters;
using ProjectDemo.Models.Rooms;
using ProjectDemo.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDemo.Views
{
    public class Display
    {
        private const string InvalidUsernameMessage = "This username already exists!";
        private const string InvalidLogInMessage = "Wrong username/password!";
        private const string InvalidInputMessage = "Please enter a valid input!";
        private const string InvalidStageMessage = "Please enter a valid stage type!";
        private const string InvalidWeaponMessage = "Please enter a valid weapon type!";
        private const string InvalidFighterMessage = "Please enter a valid fighter type!";
        private const string InvalidFighterNameMessage = "The fighter's name must be between 3 and 50 characters";

        private List<string> validWeapons;
        private List<string> validStages;
        private List<string> validFighters;
        private List<string> validUserAnswers;

        public string Username { get; set; }

        public string Password { get; set; }

        public string StageType { get; set; }

        public string[] Fighters { get; set; }

        public string[] FightersName { get; set; }

        public List<String> FirstFighterWeapons { get; set; }

        public List<String> SecondFighterWeapons { get; set; }
        public List<string> ValidWeapons { get => validWeapons; private set => validWeapons = value; }
        public List<string> ValidStages { get => validStages; private set => validStages = value; }
        public List<string> ValidFighters { get => validFighters; private set => validFighters = value; }
        public List<string> ValidUserAnswers { get => validUserAnswers; private set => validUserAnswers = value; }

        public Display()
        {
            ValidWeapons = new List<string>() { "longsword", "knife", "gladius", "angon" };
            ValidStages = new List<string>() { "skystage", "lavastage", "landstage", "icestage" };
            ValidFighters = new List<string>() { "warrior", "matador", "prisoner", "scientist" };
            ValidUserAnswers = new List<string>() { "yes", "no" };

            Authenticate();

            GetValues();
        }

        private void Authenticate()
        {
            Console.WriteLine("Do you have an account?");
            Console.WriteLine("Type in [YES] or [NO]:");
            string userAnswer = Console.ReadLine().ToLower();
            Console.WriteLine();

            while (!ValidUserAnswers.Contains(userAnswer))
            {
                Console.WriteLine(InvalidInputMessage);

                Console.WriteLine("Try again:");
                userAnswer = Console.ReadLine();
                Console.WriteLine();
            }

            if (userAnswer == "no")
            {
                Console.Clear();
                RenderSignUp();
                RenderLogIn();
            }
            else if (userAnswer == "yes")
            {
                Console.Clear();
                RenderLogIn();
            }

        }

        public void PrintLogInError()
        {
            Console.WriteLine(InvalidLogInMessage);
            Thread.Sleep(1500);
            Console.Clear();
            Authenticate();
        }

        private void GetValues()
        {
            Fighters = new string[2];
            FirstFighterWeapons = new List<string> { };
            SecondFighterWeapons = new List<string> { };
            FightersName = new string[2];

            //Taking stage-type
            TakeStage();

            //First fighter
            TakeFirstFighter();
            TakeFirstFighterWeapons();


            //SEPERATOR
            Console.WriteLine();
            Console.WriteLine("Now its the second fighter's turn...");
            Console.WriteLine();

            //Second fighter
            TakeSecondFighter();
            TakeSecondFighterWeapons();

        }

        private void TakeFirstFighterWeapons()
        {
            Console.Write("Give the fighter some weapons: ");

            FirstFighterWeapons = Console.ReadLine().Split(' ').Take(2).ToList();
            Console.WriteLine();

            while (!ValidateWeapons(FirstFighterWeapons))
            {
                Console.WriteLine(InvalidWeaponMessage);

                Console.Write("Give the fighter some weapons: ");
                FirstFighterWeapons = Console.ReadLine().Split(' ').Take(2).ToList();
                Console.WriteLine();
            }
        }

        private void TakeSecondFighterWeapons()
        {
            Console.Write("Give the fighter some weapons: ");

            SecondFighterWeapons = Console.ReadLine().Split(' ').Take(2).ToList();
            Console.WriteLine();

            while (!ValidateWeapons(SecondFighterWeapons))
            {
                Console.WriteLine(InvalidWeaponMessage);

                Console.Write("Give the fighter some weapons: ");
                SecondFighterWeapons = Console.ReadLine().Split(' ').Take(2).ToList();
                Console.WriteLine();
            }
        }

        private void TakeFirstFighter()
        {
            Console.Write("Please enter the type of the first fighter: ");

            Fighters[0] = Console.ReadLine();
            Console.WriteLine();

            while (!ValidFighters.Contains(Fighters[0].ToLower()))
            {
                Console.WriteLine(InvalidFighterMessage);

                Console.Write("Please enter the type of the first fighter: ");
                Fighters[0] = Console.ReadLine();
                Console.WriteLine();
            }

            Console.Write("And his name is: ");
            FightersName[0] = Console.ReadLine();

            while (FightersName[0].Length < 3 || FightersName[0].Length > 50)
            {
                Console.WriteLine(InvalidFighterNameMessage);

                Console.Write("And his name is: ");
                FightersName[0] = Console.ReadLine();
                Console.WriteLine();
            }
        }

        private void TakeSecondFighter()
        {
            Console.Write("Please enter the type of the second fighter: ");

            Fighters[1] = Console.ReadLine();
            Console.WriteLine();

            while (!ValidFighters.Contains(Fighters[1].ToLower()))
            {
                Console.WriteLine(InvalidFighterMessage);

                Console.Write("Please enter the type of the second fighter: ");
                Fighters[1] = Console.ReadLine();
                Console.WriteLine();
            }

            Console.Write("And his name is: ");
            FightersName[1] = Console.ReadLine();

            while (FightersName[1].Length < 3 || FightersName[1].Length > 50)
            {
                Console.WriteLine(InvalidFighterNameMessage);

                Console.Write("And his name is: ");
                FightersName[1] = Console.ReadLine();
                Console.WriteLine();
            }
        }

        private void TakeStage()
        {

            Console.Write("Please choose stage type: ");

            StageType = Console.ReadLine();
            Console.WriteLine();

            while (!ValidStages.Contains(StageType.ToLower()))
            {
                Console.WriteLine(InvalidStageMessage);

                Console.Write("Please choose stage type: ");
                StageType = Console.ReadLine();
                Console.WriteLine();

            }
            Console.WriteLine();
        }

        private bool ValidateWeapons(List<string> weapons)
        {
            foreach (var weapon in weapons)
            {
                if (!ValidWeapons.Contains(weapon.ToLower()))
                {
                    return false;
                }

            }
            return true;
        }

        private void RenderSignUp()
        {
            Console.Write("Username: ");
            Username = Console.ReadLine();
            while (Username.Length > 20)
            {
                Console.WriteLine();
                Console.WriteLine("Username can't be longer than 20 symbols!");
                Thread.Sleep(1500);
                Console.Clear();

                Console.Write("Username: ");
                Username = Console.ReadLine();
            }
            while (IsUserExisting(Username))
            {
                Console.WriteLine(InvalidUsernameMessage);
                Thread.Sleep(700);
                Console.Clear();
                RenderSignUp();
            }


            Console.Write("Password: ");
            Password = Console.ReadLine().ToLower();
            while (Password.Length <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("Password can't be null!");
                Thread.Sleep(1500);
                Console.Clear();

                RenderSignUp();
                return;
            }

            Console.Write("Confirm password: ");
            string confirmPassword = Console.ReadLine().ToLower();
            while (confirmPassword != Password)
            {
                Console.WriteLine();
                Console.WriteLine("Passwords don't match!");
                Thread.Sleep(1500);

                Console.Clear();

                Console.Write("Username: ");
                Username = Console.ReadLine();

                Console.Write("Password: ");
                Password = Console.ReadLine().ToLower();

                Console.Write("Confirm password: ");
                confirmPassword = Console.ReadLine().ToLower();

            }

            RegisterUser(Username, Password);

            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("Loading..");
            Thread.Sleep(1000);
            Console.Clear();


        }

        private void RegisterUser(string username, string password)
        {
            SqlConnection connection = new SqlConnection(Connection.CONNECTION_STRING);
            connection.Open();

            using (connection)
            {
                string sql =
                    $"INSERT INTO Users (Username, Password) VALUES (@username, @password)";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();

            }
        }

        private void RenderLogIn()
        {
            Console.Write("Username: ");
            this.Username = Console.ReadLine();
            while (Username.Length > 20)
            {
                Console.WriteLine();
                Console.WriteLine("Username can't be longer than 20 symbols!");
                Thread.Sleep(1500);
                Console.Clear();

                Console.Write("Username: ");
                Username = Console.ReadLine();
            }

            Console.Write("Password: ");
            this.Password = Console.ReadLine().ToLower();

            Console.Clear();

            if (!IsPasswordValid(this.Username, this.Password))
            {
                PrintLogInError();
            }

        }

        private static bool IsPasswordValid(string username, string password)
        {
            int matchedUsersCount = 0;

            SqlConnection connection = new SqlConnection(Connection.CONNECTION_STRING);
            connection.Open();

            using (connection)
            {
                string sql =
                    $"SELECT COUNT(*) FROM Users " +
                    $"Where Username = @username AND " +
                    $" Password = @password";

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                matchedUsersCount = (int)cmd.ExecuteScalar();
            }
            return matchedUsersCount > 0;

        }

        private static bool IsUserExisting(string username)
        {
            int matchedUsersCount = 0;

            SqlConnection connection = new SqlConnection(Connection.CONNECTION_STRING);
            connection.Open();

            using (connection)
            {
                string sql =
                    $"SELECT COUNT(*) FROM Users " +
                    $"Where Username = @username";

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@username", username);
                matchedUsersCount = (int)cmd.ExecuteScalar();
            }
            return matchedUsersCount == 1;

        }
    }
}