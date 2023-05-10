using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.DL;

namespace Task02.BL
{
    public class Login
    {
        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string username;
        public string password;
        public int CheckRole()
        {
            int choice = 0;
            if (username == "admin" && password == "admin")
            {
                choice = 1;
            }
            else
            {
                for (int i = 0; i < EmployeeCRUD.Employees.Count; i++)
                {
                    if (username == EmployeeCRUD.Employees[i].usernameE && password == EmployeeCRUD.Employees[i].passwordE)
                    {
                        choice = 2; // for employee
                        break;
                    }
                    else
                    {
                        choice = 3;
                    }
                }
            }
            return choice;
        }
    }
}
