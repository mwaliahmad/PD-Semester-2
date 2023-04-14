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
        static string path = "D:\\Github\\PD2\\Week02\\Task01\\Task01\\Employee.txt";
        static void Main(string[] args)
        {
            List<Employee> E = new List<Employee>();
            LoadEmployee(E);
            while (true)
            {
                Console.Clear();
                printHeader();
                int user = login();
                if (user == 1)
                {

                    Console.Clear(); // calling admin interference
                    printHeader();
                    adminMenu(E);
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

        static void adminMenu(List<Employee> E)
        {
            int choice = 0;
            while (choice != 10)
            {
                Console.Clear();
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
                    Console.Clear();
                    printHeader();
                    addEmployee(E);
                }
                if (choice == 2)
                {
                    Console.Clear();
                    printHeader();
                    deleteEmployee(E);
                }
                if (choice == 3)
                {
                    Console.Clear();
                    printHeader();
                    updateEmployee(E);
                }
                if (choice == 4)
                {
                    Console.Clear();
                    printHeader();
                    searchEmployee(E);
                }
                if (choice == 5)
                {
                    Console.Clear();
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
        static int login()
        {
            string username, password;
            int choice;
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

            if (username == "admin" && password == "admin")
            {
                choice = 1; // for admin
            }
            else
            {
                choice = 3;
            }
            return choice;
        }

        static void printHeader()
        {
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
        static void addEmployee(List<Employee> E)
        {
            Console.WriteLine();
            string menu = "Admin Menu"; // submenu variables
            string subMenu = "Add Employee";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter Details of the New Employee:-");
            Console.WriteLine();
            Employee E1 = new Employee();
            Console.Write("Enter Name: ");
            E1.nameE = isAlpha(E1.nameE);
            Console.Write("Enter Age(+18): ");
            E1.ageE = isNum(E1.ageE);
            Console.Write("Enter CNIC(13 numbers): ");
            E1.cnicE = cnicCheck(E1.cnicE);
            Console.Write("Enter Contact No(11 numbers): ");
            E1.contactE = contactCheck(E1.contactE);
            Console.Write("Enter Username: ");
            E1.usernameE = usercheck(E1.usernameE,E);
            Console.Write("Enter Password: ");
            E1.passwordE = Console.ReadLine();

            EmployeeToFile(E1.nameE, E1.ageE ,E1.cnicE,E1.contactE,E1.usernameE,E1.passwordE); // to file
            E.Add(E1);

            
            Console.WriteLine();
            Console.WriteLine("Employee Added Sucessfully...");
            Thread.Sleep(300);
            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();
        }
        static void deleteEmployee(List<Employee> E)
        {

            int index;
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
            bool notFound = true;
            for (int idx = 0; idx < E.Count; idx++)
            {
                if (deleteName == E[idx].usernameE)
                {
                    index = idx;
                    Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "CNIC".PadRight(20) + "Contact No.".PadRight(20) + "Username".PadRight(20) + "Password".PadRight(20));
                    Console.WriteLine();
                    Console.WriteLine(E[idx].nameE.PadRight(20) + E[idx].ageE.PadRight(20) + E[idx].cnicE.PadRight(20) + E[idx].contactE.PadRight(20) + E[idx].usernameE.PadRight(20) + E[idx].passwordE.PadRight(20));

                    E.RemoveAt(index);
                    
                    updateEmployeeFile(E);
                    Console.WriteLine();
                    Console.WriteLine("Employee Removed...");
                    notFound = true;
                    break;
                }
                else
                {
                    notFound = false;
                }
            }
            if (notFound == false)
            {
                Console.WriteLine();
                Console.WriteLine("Employee Not Found");
                Console.WriteLine();
                Console.WriteLine("Press any key for back...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Press any key for back...");
                Console.ReadKey();
            }

        }
        static void updateEmployee(List<Employee> E)
        {
            int index;
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
            bool notFound = true;
            for (int idx = 0; idx < E.Count; idx++)
            {
                if (updateName == E[idx].usernameE)
                {
                    index = idx;
                    Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "CNIC".PadRight(20) + "Contact No.".PadRight(20) + "Username".PadRight(20) + "Password".PadRight(20));
                    Console.WriteLine();
                    Console.WriteLine(E[idx].nameE.PadRight(20) + E[idx].ageE.PadRight(20) + E[idx].cnicE.PadRight(20) + E[idx].contactE.PadRight(20) + E[idx].usernameE.PadRight(20) + E[idx].passwordE.PadRight(20));

                    Console.WriteLine(); // update details

                    Employee E1 = new Employee();
                    Console.Write("Enter Name: ");
                    E1.nameE = isAlpha(E1.nameE);
                    Console.Write("Enter Age(+18): ");
                    E1.ageE = isNum(E1.ageE);
                    Console.Write("Enter CNIC(13 numbers): ");
                    E1.cnicE = cnicCheck(E1.cnicE);
                    Console.Write("Enter Contact No(11 numbers): ");
                    E1.contactE = contactCheck(E1.contactE);
                    Console.Write("Enter Username: ");
                    E1.usernameE = usercheck(E1.usernameE,E);
                    Console.Write("Enter Password: ");
                    E1.passwordE = Console.ReadLine();

                    E[idx] = E1;
                    updateEmployeeFile(E);
                    Console.WriteLine();
                    Console.WriteLine("Employee Updated...");

                    notFound = true;
                    break;
                }
                else
                {
                    notFound = false;
                }
            }
            if (notFound == false)
            {
                Console.WriteLine();
                Console.WriteLine("Employee Not Found");
                Console.WriteLine();
                Console.WriteLine("Press any key for back...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Press any key for back...");
                Console.ReadKey();
            }
        }
        static void searchEmployee(List<Employee> E)
        {
            int index;
            string searchName;
            Console.WriteLine();
            string menu = "Admin Menu"; // submenu variables
            string subMenu = "Search Employee";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter username of the Employee: "); // username employee
            searchName = Console.ReadLine();
            bool notFound = true;
            bool one = false;
            Console.WriteLine();
            Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "CNIC".PadRight(20) + "Contact No.".PadRight(20) + "Username".PadRight(20) + "Password".PadRight(20));
            Console.WriteLine();

            for (int idx = 0; idx < E.Count; idx++)
            {
                if (searchName == E[idx].usernameE)
                {
                    index = idx;
                    Console.WriteLine(E[idx].nameE.PadRight(20) + E[idx].ageE.PadRight(20) + E[idx].cnicE.PadRight(20) + E[idx].contactE.PadRight(20) + E[idx].usernameE.PadRight(20) + E[idx].passwordE.PadRight(20));

                    notFound = true;
                    one = true;
                }
                else if (one == false)
                {
                    notFound = false;
                }
            }
            if (notFound == false)
            {
                Console.WriteLine();
                Console.WriteLine("Employee Not Found");
                Console.WriteLine();
                Console.WriteLine("Press any key for back...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Press any key for back...");
                Console.ReadKey();
            }
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
            Console.WriteLine();
            Console.WriteLine(); // display all
            for (int idx = 0; idx < E.Count; idx++)
            {
                if (E[idx].usernameE != "")
                {
                    Console.WriteLine(E[idx].nameE.PadRight(20) + E[idx].ageE.PadRight(20) + E[idx].cnicE.PadRight(20) + E[idx].contactE.PadRight(20) + E[idx].usernameE.PadRight(20) + E[idx].passwordE.PadRight(20));
                    flag = true;
                }
            }

            if (flag == false)
            {
                Console.WriteLine("Employees not Found");
                Console.WriteLine("Add Employees to View Employees");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();
        }
        static void LoadEmployee(List<Employee> E)
        {
            StreamReader employeeData = new StreamReader(path);
            string line = "";
            while ((line = employeeData.ReadLine()) != null)
            {
                if (line != "")
                {
                    Employee E1 = new Employee();

                    E1.nameE = Dataparse(line, 1);

                    E1.ageE = Dataparse(line, 2);

                    E1.cnicE = Dataparse(line, 3);

                    E1.contactE = Dataparse(line, 4);

                    E1.usernameE = Dataparse(line, 5);

                    E1.passwordE = Dataparse(line, 6);
                    E.Add(E1);
                }
            }
            employeeData.Close();
        }
        static void EmployeeToFile(string name, string age, string cnic, string contact, string username, string password)
        {
            StreamWriter employeeData = new StreamWriter(path, true);
            employeeData.WriteLine(name + "," + age + "," + cnic + "," + contact + "," + username + "," + password);
            employeeData.Flush();
            employeeData.Close();
        }

        static void updateEmployeeFile(List<Employee> E)
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