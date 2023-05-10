using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.DL;

namespace Task02.BL
{
    public class Employee
    {
        public Employee(string nameE, string ageE, string contactE, string cnicE, string usernameE, string passwordE)
        {
            this.nameE = nameE;
            this.ageE = ageE;
            this.contactE = contactE;
            this.cnicE = cnicE;
            this.usernameE = usernameE;
            this.passwordE = passwordE;
            donors = new List<Donor>();
            recipients = new List<Recipient>();
        }
        public string nameE;
        public string ageE;
        public string contactE;
        public string cnicE;
        public string usernameE;
        public string passwordE;
        public List<Donor> donors;
        public List<Recipient> recipients;
        public string GetUsername()
        {
            return usernameE;
        }
    }
}
