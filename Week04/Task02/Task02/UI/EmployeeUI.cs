using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.UI
{
    public class EmployeeUI
    {
        public static void printAMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1.  Add New Donor...");
            Console.WriteLine("2.  Delete Donor... ");
            Console.WriteLine("3.  Update Donor Details... ");
            Console.WriteLine("4.  Search For Donor... ");
            Console.WriteLine("5.  View all Donors... ");
            Console.WriteLine("6.  Add New Recipient...");
            Console.WriteLine("7.  Delete Recipient... ");
            Console.WriteLine("8.  Update Recipient.Details... ");
            Console.WriteLine("9.  Search For Recipient... ");
            Console.WriteLine("10.  View all Recipients... ");
            Console.WriteLine("11. Log out... ");
            Console.WriteLine();
            Console.Write("Enter Your Option: ");
        }
    }
}
