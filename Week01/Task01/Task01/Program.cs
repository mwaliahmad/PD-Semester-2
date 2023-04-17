using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Task01
{
    class Program
    {
        static string[] nameE = new string[100];
        static string[] ageE = new string[100];
        static string[] contactE = new string[100];
        static string[] cnicE = new string[100];
        static string[] usernameE = new string[100];
        static string[] passwordE = new string[100];
        static int indexE = 0;
        static string path = "Employee.txt";

        static void Main(string[] args)
        {
            LoadEmployee();
            while (true)
            {
                Console.Clear();
                printHeader();
                int user = login();
                if (user == 1)
                {

                    Console.Clear(); // calling admin interference
                    printHeader();
                    adminMenu();
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

        static void adminMenu()
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
                    addEmployee();
                }
                if (choice == 2)
                {
                    Console.Clear();
                    printHeader();
                    deleteEmployee();
                }
                if (choice == 3)
                {
                    Console.Clear();
                    printHeader();
                   updateEmployee();
                }
                if (choice == 4)
                {
                    Console.Clear();
                    printHeader();
                    searchEmployee();
                }
                if (choice == 5)
                {
                    Console.Clear();
                    printHeader();
                    viewEmployee();
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
        static void addEmployee()
        {
            Console.WriteLine();
            string menu = "Admin Menu"; // submenu variables
            string subMenu = "Add Employee";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter Details of the New Employee:-");
            Console.WriteLine();

            Console.Write("Enter Name: ");
            nameE[indexE] = isAlpha(nameE[indexE]);
            Console.Write("Enter Age(+18): ");
            ageE[indexE] = isNum(ageE[indexE]);
            Console.Write("Enter CNIC(13 numbers): ");
            cnicE[indexE] = cnicCheck(cnicE[indexE]);
            Console.Write("Enter Contact No(11 numbers): ");
            contactE[indexE] = contactCheck(contactE[indexE]);
            Console.Write("Enter Username: ");
            usernameE[indexE] = usercheck(usernameE[indexE]);
            Console.Write("Enter Password: ");
            passwordE[indexE] = Console.ReadLine();

            EmployeeToFile(nameE[indexE], ageE[indexE], cnicE[indexE], contactE[indexE], usernameE[indexE], passwordE[indexE]); // to file
            indexE++;
            Console.WriteLine();
            Console.WriteLine("Employee Added Sucessfully...");
            Thread.Sleep(300);
            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();
        }
        static void deleteEmployee()
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
            for (int idx = 0; idx < 100; idx++)
            {
                if (deleteName == usernameE[idx])
                {
                    index = idx;
                    Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "CNIC".PadRight(20) + "Contact No.".PadRight(20) + "Username".PadRight(20) + "Password".PadRight(20));
                    Console.WriteLine();
                    Console.WriteLine(nameE[index].PadRight(20) + ageE[index].PadRight(20) + cnicE[index].PadRight(20) + contactE[index].PadRight(20) + usernameE[index].PadRight(20) + passwordE[index].PadRight(20));

                    for (int j = idx; j <= indexE; j++) // moving arrays one index back
                    {
                        nameE[j] = nameE[j + 1];
                        ageE[j] = ageE[j + 1];
                        cnicE[j] = cnicE[j + 1];
                        contactE[j] = contactE[j + 1];
                        usernameE[j] = usernameE[j + 1];
                        passwordE[j] = passwordE[j + 1];
                    }
                    indexE--;
                    updateEmployeeFile();
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
        static void updateEmployee()
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
            for (int idx = 0; idx < 100; idx++)
            {
                if (updateName == usernameE[idx])
                {
                    index = idx;
                    Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "CNIC".PadRight(20) + "Contact No.".PadRight(20) + "Username".PadRight(20) + "Password".PadRight(20));
                    Console.WriteLine();
                    Console.WriteLine(nameE[index].PadRight(20) + ageE[index].PadRight(20) + cnicE[index].PadRight(20) + contactE[index].PadRight(20) + usernameE[index].PadRight(20) + passwordE[index].PadRight(20));
                    Console.WriteLine(); // update details
                  
                    Console.Write("Enter Name: ");
                    nameE[index] = isAlpha(nameE[indexE]);
                    Console.Write("Enter Age(+18): ");
                    ageE[index] = isNum(ageE[indexE]);
                    Console.Write("Enter CNIC(13 numbers): ");
                    cnicE[index] = cnicCheck(cnicE[indexE]);
                    Console.Write("Enter Contact No(11 numbers): ");
                    contactE[index] = contactCheck(contactE[indexE]);
                    Console.Write("Enter Username: ");
                    usernameE[index] = usercheck(usernameE[indexE]);
                    Console.Write("Enter Password: ");
                    passwordE[index] = Console.ReadLine();

                    updateEmployeeFile();
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
        static void searchEmployee()
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

            for (int idx = 0; idx < 100; idx++)
            {
                if (searchName == usernameE[idx])
                {
                    index = idx;
                    Console.WriteLine(nameE[index].PadRight(20) + ageE[index].PadRight(20) + cnicE[index].PadRight(20) + contactE[index].PadRight(20) + usernameE[index].PadRight(20) + passwordE[index].PadRight(20));
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
        static void viewEmployee()
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
            for (int index = 0; index < indexE; index++)
            {
                if (nameE[index] != "")
                {
                    Console.WriteLine(nameE[index].PadRight(20) + ageE[index].PadRight(20) + cnicE[index].PadRight(20) + contactE[index].PadRight(20) + usernameE[index].PadRight(20) + passwordE[index].PadRight(20));
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
        static void LoadEmployee()
        {
            StreamReader employeeData = new StreamReader(path);
            string line = "";
            while ((line = employeeData.ReadLine()) != null)
            {
                if (line != "")
                {
                    nameE[indexE] = Dataparse(line, 1);

                    ageE[indexE] = Dataparse(line, 2);

                    cnicE[indexE] = Dataparse(line, 3);

                    contactE[indexE] = Dataparse(line, 4);

                    usernameE[indexE] = Dataparse(line, 5);

                    passwordE[indexE] = Dataparse(line, 6);
                    indexE++;
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

        static void updateEmployeeFile()
        {
            StreamWriter employeeData = new StreamWriter(path);
            for (int i = 0; i < indexE; i++)
            {
                if (nameE[i] != "")
                {
                    employeeData.WriteLine(nameE[i] + "," + ageE[i] + "," + cnicE[i] + "," + contactE[i] + "," + usernameE[i] + "," + passwordE[i]);
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
        static string usercheck(string username) // username validation
        {
            username = Console.ReadLine();
            for (int i = 0; i < 100; i++)
            {
                if (username == usernameE[i] && username != "admin")
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