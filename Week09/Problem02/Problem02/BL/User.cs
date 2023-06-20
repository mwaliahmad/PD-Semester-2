using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02.BL
{
   public class User
    {
        private string username;
        private string password;
        private string role;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public User(string Username, string Password, string Role)
        {
            this.Username = Username;
            this.Password = Password;
            this.Role = Role;
        }
        public string GetUsername()
        {
            return Username;
        }
        public string GetPassword()
        {
            return Password;
        }
        public string GetRole()
        {
            return Role;
        }
        public bool isAdmin()
        {
            if (Role == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
