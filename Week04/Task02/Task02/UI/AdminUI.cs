﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Task02.BL;

namespace Task02.UI
{
    class AdminUI
    {
        public static Employee addEmployee()
        {
            Common.menuName("Admin Menu", "Add Employee");
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
        public static string SearchEmployee(string menu, string submenu)
        {
            Common.menuName(menu, submenu);
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

        public static void EmployeeHeading()
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
    }
}
