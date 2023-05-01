using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using Task01.BL;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Employee.txt";
            List<Employee> E = new List<Employee>();
            LoadEmployee(path, E);
            while (true)
            {
                printHeader();
                int user = login(E);
                if (user == 1)
                {
                    // calling admin interference
                    printHeader();
                    adminMenu(path, E);
                }
                else if (user == 2)
                {
                    Console.WriteLine("User");
                    Console.Read();
                }
                else if (user == 3)
                {
                    Console.WriteLine(); // if wrong credentials
                    Console.WriteLine("Wrong Credentials!! Try again!!");
                    Thread.Sleep(300);
                }
            }
            // Console.Read();

        }

        static void adminMenu(string path, List<Employee> E)
        {
            int choice = 0;
            while (choice != 10)
            {
                printHeader();
                Console.WriteLine();
                Console.WriteLine();
                string menu = "Login"; // submenu variables
                string subMenu = "Admin Menu";
                menuName(menu, subMenu);

                printAMenu();                 // menu

                choice = choiceCheck();

                if (choice == 1)
                {
                    printHeader();
                    addEmployee(path, E);
                }
                if (choice == 2)
                {
                    printHeader();
                    deleteEmployee(path, E);
                }
                if (choice == 3)
                {
                    printHeader();
                    updateEmployee(path, E);
                }
                if (choice == 4)
                {
                    printHeader();
                    searchEmployee(E);
                }
                if (choice == 5)
                {
                    printHeader();
                    viewEmployee(E);
                }
            }
        }

        static void printAMenu()
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
        static int login(List<Employee> E)
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

            Employee E1 = new Employee(username,password);
            int choice = E1.CheckRole(E);
            return choice;
        }

        static void printHeader()
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
        static void addEmployee(string path, List<Employee> E)
        {
            string name = "";
            string age = "";
            string cnic = "";
            string contact = "";
            string username = "";
            string password = "";

            Console.WriteLine();
            string menu = "Admin Menu"; // submenu variables
            string subMenu = "Add Employee";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter Details of the New Employee:-");
            Console.WriteLine();
            Console.Write("Enter Name: ");
            name = isAlpha(name);

            Console.Write("Enter Age(+18): ");
            age = isNum(age);

            Console.Write("Enter CNIC(13 numbers): ");
            cnic = cnicCheck(cnic);

            Console.Write("Enter Contact No(11 numbers): ");
            contact = contactCheck(contact);

            Console.Write("Enter Username: ");
            username = usercheck(username, E);

            Console.Write("Enter Password: ");
            password = Console.ReadLine();

            Employee E1 = new Employee(name, age, contact, cnic, username, password);

            EmployeeToFile(path, E1); // to file
            AddEmployeeToList(E, E1);


            Console.WriteLine();
            Console.WriteLine("Employee Added Sucessfully...");
            Thread.Sleep(300);
            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();
        }
        static void deleteEmployee(string path, List<Employee> E)
        {
            string deleteName;
            Console.WriteLine();
            string menu = "Admin Menu"; // submenu variables
            string subMenu = "Delete Employee";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter Username of the Employee: ");
            deleteName = Console.ReadLine();
            Console.WriteLine();

            int index = SearchEmployeeIndex(deleteName, E);


            Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "CNIC".PadRight(20) + "Contact No.".PadRight(20) + "Username".PadRight(20) + "Password".PadRight(20));
            Console.WriteLine();

            if (index != -1)
            {
                DisplaySingleEmployee(index, E);
                DeleteEmployeeToList(E, index);
                updateEmployeeFile(path, E);

                Console.WriteLine();
                Console.WriteLine("Employee Removed...");
            }
            else if (index == -1)
            {
                Console.WriteLine();
                Console.WriteLine("Employee Not Found");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();
        }
        static void updateEmployee(string path, List<Employee> E)
        {
            string name = "";
            string age = "";
            string cnic = "";
            string contact = "";
            string username = "";
            string password = "";

            string updateName;
            Console.WriteLine();
            string menu = "Admin Menu"; // submenu variables
            string subMenu = "Update Employee";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter username of the Employee: ");
            updateName = Console.ReadLine();
            Console.WriteLine();

            int index = SearchEmployeeIndex(updateName, E);

            Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "CNIC".PadRight(20) + "Contact No.".PadRight(20) + "Username".PadRight(20) + "Password".PadRight(20));
            Console.WriteLine();

            if (index != -1)
            {
                DisplaySingleEmployee(index, E);

                Console.WriteLine(); // update details

                Console.Write("Enter Name: ");
                name = isAlpha(name);

                Console.Write("Enter Age(+18): ");
                age = isNum(age);

                Console.Write("Enter CNIC(13 numbers): ");
                cnic = cnicCheck(cnic);

                Console.Write("Enter Contact No(11 numbers): ");
                contact = contactCheck(contact);

                Console.Write("Enter Username: ");
                username = usercheck(username, E);

                Console.Write("Enter Password: ");
                password = Console.ReadLine();

                Employee E1 = new Employee(name, age, contact, cnic, username, password);

                E[index] = E1;
                updateEmployeeFile(path, E);

                Console.WriteLine();
                Console.WriteLine("Employee Updated...");
            }
            else if (index == -1)
            {
                Console.WriteLine();
                Console.WriteLine("Employee Not Found");

            }

            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();

        }
        static void searchEmployee(List<Employee> E)
        {
            string searchName;
            Console.WriteLine();
            string menu = "Admin Menu"; // submenu variables
            string subMenu = "Search Employee";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter username of the Employee: "); // username employee
            searchName = Console.ReadLine();

            int index = SearchEmployeeIndex(searchName, E);

            Console.WriteLine();
            Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "CNIC".PadRight(20) + "Contact No.".PadRight(20) + "Username".PadRight(20) + "Password".PadRight(20));
            Console.WriteLine();

            if (index !=-1)
            {
                DisplaySingleEmployee(index, E);
            }
            else if (index == -1)
            {
                Console.WriteLine();
                Console.WriteLine("Employee Not Found");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();

        }
        static void viewEmployee(List<Employee> E)
        {
            bool flag = false;
            Console.WriteLine();
            string menu = "Admin Menu"; // submenu variables
            string subMenu = "View All Employees";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Following Are the Employees: ");
            Console.WriteLine();
            
            Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "CNIC".PadRight(20) + "Contact No.".PadRight(20) + "Username".PadRight(20) + "Password".PadRight(20));
            Console.WriteLine(); // display all

            for (int idx = 0; idx < E.Count; idx++)
            {
                DisplaySingleEmployee(idx, E);
            }

            if (E.Count == 0)
            {
                Console.WriteLine("Employees not Found");
                Console.WriteLine("Add Employees to View Employees");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();
        }
        static void LoadEmployee(string path, List<Employee> E)
        {
            StreamReader employeeData = new StreamReader(path);
            string line = "";
            while ((line = employeeData.ReadLine()) != null)
            {
                if (line != "")
                {
                    string name = Dataparse(line, 1);

                    string age = Dataparse(line, 2);

                    string cnic = Dataparse(line, 3);

                    string contact = Dataparse(line, 4);

                    string username = Dataparse(line, 5);

                    string password = Dataparse(line, 6);

                    Employee E1 = new Employee(name, age, contact, cnic, username, password);
                    AddEmployeeToList(E, E1);
                }
            }
            employeeData.Close();
        }
        static void AddEmployeeToList(List<Employee> E, Employee E1)
        {
            E.Add(E1);
        }
        static void DeleteEmployeeToList(List<Employee> E, int index)
        {
            E.RemoveAt(index);
        }
        static void EmployeeToFile(string path, Employee E)
        {
            StreamWriter employeeData = new StreamWriter(path, true);
            employeeData.WriteLine(E.nameE + "," + E.ageE + "," + E.cnicE + "," + E.contactE + "," + E.usernameE + "," + E.passwordE);
            employeeData.Flush();
            employeeData.Close();
        }

        static void updateEmployeeFile(string path, List<Employee> E)
        {
            StreamWriter employeeData = new StreamWriter(path);
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].nameE != "")
                {
                    employeeData.WriteLine(E[i].nameE + "," + E[i].ageE + "," + E[i].cnicE + "," + E[i].contactE + "," + E[i].usernameE + "," + E[i].passwordE);
                }
            }
            employeeData.Flush();
            employeeData.Close();
        }
        static string Dataparse(string line, int field)
        {
            int comma = 1;
            string item = "";
            int length = line.Length;
            for (int i = 0; i < length; i++)
            {
                if (line[i] == ',')
                {
                    comma++;
                }
                else if (field == comma)
                {
                    item = item + line[i];
                }
            }
            return item;
        }
        static void menuName(string menu, string subMenu)
        {
            Console.WriteLine("  " + menu + " > " + subMenu);
            Console.WriteLine("-------------------------------");
        }
        static int SearchEmployeeIndex(string name, List<Employee> E)
        {
            int index = -1;

            for (int idx = 0; idx < E.Count; idx++)
            {
                if (name == E[idx].usernameE)
                {
                    index = idx;
                    break;
                }
            }
            return index;
        }

        static void DisplaySingleEmployee(int index, List<Employee> E)
        {

            for (int idx = 0; idx < E.Count; idx++)
            {
                if (index == idx)
                {
                    Console.WriteLine(E[idx].nameE.PadRight(20) + E[idx].ageE.PadRight(20) + E[idx].cnicE.PadRight(20) + E[idx].contactE.PadRight(20) + E[idx].usernameE.PadRight(20) + E[idx].passwordE.PadRight(20));
                }
            }

        }

        static int choiceCheck() // choice validation
        {
            int choice;
            string opt;

            opt = Console.ReadLine();
            while (true)
            {
                if (int.TryParse(opt, out choice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Option...");
                    Console.Write("Enter Option: ");
                    opt = Console.ReadLine();
                }
            }
            return choice;
        }
        static string isAlpha(string input)
        {
            input = Console.ReadLine();
            int size;
            int check;
            bool flap = true;
            while (true)
            {
                size = input.Length;
                for (int i = 0; i < size; i++)
                {
                    check = (int)input[i];
                    if ((check >= 65 && check <= 90) || (check >= 97 && check <= 122) || input[i] == ' ')
                    {
                        flap = true;
                    }
                    else
                    {
                        flap = false;
                        break;
                    }
                }
                if (flap == true)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Wrong Character...");
                    Console.Write("Enter Again: ");
                    input = Console.ReadLine();
                }
            }
        }
        static string isNum(string input)
        {
            input = Console.ReadLine();
            int x;
            int size;
            int check;
            bool flap = true;
            while (true)
            {
                size = input.Length;
                for (int i = 0; i < size; i++)
                {
                    if (input[i] != ' ')
                    {
                        check = (int)input[i];
                        if ((check >= 48 && check <= 57))
                        {
                            flap = true;
                        }
                        else
                        {
                            flap = false;
                            break;
                        }
                    }
                }
                if (flap == true)
                {
                    x = int.Parse(input);
                    if (x >= 18 && x <= 60)
                    {
                        return input;
                    }
                    else
                    {

                        Console.WriteLine("Wrong Age...");
                        Console.Write("Enter age: ");
                        input = Console.ReadLine();
                    }
                }
                else
                {

                    Console.WriteLine("Wrong Age...");
                    Console.Write("Enter age: ");
                    input = Console.ReadLine();
                }
            }

        }

        static string contactCheck(string contact) // contact validation
        {
            contact = Console.ReadLine();
            int size;
            int check;
            bool flap = true;
            while (true)
            {
                size = contact.Length;
                for (int i = 0; i < size; i++)
                {
                    if (contact[i] != ' ')
                    {
                        check = (int)(contact[i]);
                        if ((check >= 48 && check <= 57) && (size == 11))
                        {
                            flap = true;
                        }
                        else
                        {
                            flap = false;
                            break;
                        }
                    }
                }
                if (flap == true)
                {
                    return contact;
                }
                else
                {
                    Console.WriteLine("Wrong contact...");
                    Console.Write("Enter contact: ");
                    contact = Console.ReadLine();
                }
            }
        }
        static string cnicCheck(string cnic) // cnic validation
        {
            cnic = Console.ReadLine();
            int size;
            int check;
            bool flap = true;
            while (true)
            {
                size = cnic.Length;
                for (int i = 0; i < size; i++)
                {
                    if (cnic[i] != ' ')
                    {
                        check = (int)(cnic[i]);
                        if ((check >= 48 && check <= 57) && (size == 13))
                        {
                            flap = true;
                        }
                        else
                        {
                            flap = false;
                            break;
                        }
                    }
                }
                if (flap == true)
                {
                    return cnic;
                }
                else
                {
                    Console.WriteLine("Wrong cnic...");
                    Console.Write("Enter cnic: ");
                    cnic = Console.ReadLine();
                }
            }
        }
        static string usercheck(string username, List<Employee> E) // username validation
        {
            username = Console.ReadLine();
            for (int i = 0; i < E.Count; i++)
            {
                if (username == E[i].usernameE && username != "admin")
                {
                    Console.WriteLine("Username Already Present");
                    Console.Write("Enter Again: ");
                    username = Console.ReadLine();
                }
                else
                {
                    continue;
                }
            }
            return username;
        }
    }
}