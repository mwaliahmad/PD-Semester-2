using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.BL
{
    class Employee
    {
        public Employee(string nameE, string ageE, string contactE, string cnicE, string usernameE, string passwordE)
        {
            this.nameE = nameE;
            this.ageE = ageE;
            this.contactE = contactE;
            this.cnicE = cnicE;
            this.usernameE = usernameE;
            this.passwordE = passwordE;
        }
        public Employee(string usernameE, string passwordE)
        {
            this.usernameE = usernameE;
            this.passwordE = passwordE;
        }

        public string nameE;
        public string ageE;
        public string contactE;
        public string cnicE;
        public string usernameE;
        public string passwordE;

        public int CheckRole(List<Employee> E)
        {
            int choice=0;
            if (usernameE == "admin" && passwordE =="admin")
            {
               choice = 1;
            }
            else
            {
                for (int i = 0; i <E.Count; i++)
                {
                    if (usernameE == E[i].usernameE && passwordE == E[i].passwordE)
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
