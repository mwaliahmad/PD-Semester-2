using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDMS.BL;
namespace BDMS.UI
{
    public class AdminUI
    {
        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("1.  Add New Employee...");
            Console.WriteLine("2.  Delete Employee... ");
            Console.WriteLine("3.  Update Employee Details... ");
            Console.WriteLine("4.  Search For Employee... ");
            Console.WriteLine("5.  View all Employees... ");
            Console.WriteLine("6.  Search For Donor... ");
            Console.WriteLine("7.  View all Donors... ");
            Console.WriteLine("8.  Search For Recipient... ");
            Console.WriteLine("9.  View all Recipient... ");
            Console.WriteLine("10. Log out... ");
            Console.WriteLine();
            Console.Write("Enter Your Option: ");
        }
    }
}
