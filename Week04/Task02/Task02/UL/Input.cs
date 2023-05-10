using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Task02.BL;

namespace Task02.UL
{
    class Input
    {
        public static int login()
        {
            string username, password;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Welcome to Blood Donation Management System");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Enter Username: ");
            username = Console.ReadLine();
            Console.Write("Enter Password: ");
            password = Console.ReadLine();

            Login User = new Login(username, password);
            int choice = User.CheckRole();

            return choice;
        }
        public static Employee addEmployee()
        {
            menuName("Admin Menu", "Add Employee");
            Console.WriteLine("Enter Details of the New Employee:-");
            Console.WriteLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age(+18): ");
            string age = Console.ReadLine();

            Console.Write("Enter CNIC(13 numbers): ");
            string cnic = Console.ReadLine();

            Console.Write("Enter Contact No(11 numbers): ");
            string contact = Console.ReadLine();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Employee E1 = new Employee(name, age, contact, cnic, username, password);
            return E1;
        }
        public static string SearchEmployee(string menu,string submenu)
        {
            Input.menuName(menu,submenu);
            Console.Write("Enter Username of the Employee: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            return name;
        }      
        public static Employee NewEmployee()
        {
            Console.WriteLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age(+18): ");
            string age = Console.ReadLine();

            Console.Write("Enter CNIC(13 numbers): ");
            string cnic = Console.ReadLine();

            Console.Write("Enter Contact No(11 numbers): ");
            string contact = Console.ReadLine();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Employee E1 = new Employee(name, age, contact, cnic, username, password);
            return E1;
        }
        public static void Back(string line)
        {
            Console.WriteLine();
            Console.WriteLine(line);
            Thread.Sleep(300);
            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();
        }
        public static void Heading()
        {
            Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "CNIC".PadRight(20) + "Contact No.".PadRight(20) + "Username".PadRight(20) + "Password".PadRight(20));
            Console.WriteLine();
        }
        public static void DisplayEmployee(Employee E)
        {
            Console.WriteLine(E.nameE.PadRight(20) + E.ageE.PadRight(20) + E.cnicE.PadRight(20) + E.contactE.PadRight(20) + E.usernameE.PadRight(20) + E.passwordE.PadRight(20));
        }
        public static void printAMenu()
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
        public static void menuName(string menu, string subMenu)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  " + menu + " > " + subMenu);
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void printHeader()
        {
            Console.Clear();
            DateTime now = DateTime.Now;
            Console.SetCursorPosition(78, 1);
            Console.WriteLine(now);

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("             ____  _                 _   _____                    _   _              ");
            Console.WriteLine("            |  _ \\| |               | | |  __ \\                  | | (_)                  ");
            Console.WriteLine("            | |_) | | ___   ___   __| | | |  | | ___  _ __   __ _| |_ _  ___  _ __         ");
            Console.WriteLine("            |  _ <| |/ _ \\ / _ \\ / _` | | |  | |/ _ \\| '_ \\ / _` | __| |/ _ \\| '_ \\         ");
            Console.WriteLine("            | |_) | | (_) | (_) | (_| | | |__| | (_) | | | | (_| | |_| | (_) | | | |         ");
            Console.WriteLine("            |____/|_|\\___/ \\___/ \\__,_| |_____/ \\___/|_| |_|\\__,_|\\__|_|\\___/|_| |_|          ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  __  __                                                   _      _____           _               ");
            Console.WriteLine(" |  \\/  |                                                 | |    / ____|         | |               ");
            Console.WriteLine(" | \\  / | __ _ _ __   __ _  __ _  ___ _ __ ___   ___ _ __ | |_  | (___  _   _ ___| |_ ___ _ __ ___  ");
            Console.WriteLine(" | |\\/| |/ _` | '_ \\ / _` |/ _` |/ _ \\ '_ ` _ \\ / _ \\ '_ \\| __|  \\___ \\| | | / __| __/ _ \\ '_ ` _ \\  ");
            Console.WriteLine(" | |  | | (_| | | | | (_| | (_| |  __/ | | | | |  __/ | | | |_   ____) | |_| \\__ \\ ||  __/ | | | | | ");
            Console.WriteLine(" |_|  |_|\\__,_|_| |_|\\__,_|\\__, |\\___|_| |_| |_|\\___|_| |_|\\__| |_____/ \\__, |___/\\__\\___|_| |_| |_| ");
            Console.WriteLine("                            __/ |                                        __/ |                       ");
            Console.WriteLine("                           |___/                                        |___/                      ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
