using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.UI
{
    public class GuestUI
    {
        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("1.  Search For Donor... ");
            Console.WriteLine("2.  Search For Recipient... ");
            Console.WriteLine("3. Log out... ");
            Console.WriteLine();
            Console.Write("Enter Your Option: ");
        }
    }
}
