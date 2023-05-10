using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using Task02.BL;
using Task02.DL;
using Task02.UL;

namespace Task02
{
    class Program
    {
        static string user;
        static void Main(string[] args)
        {

            // string donorFile = "DonorData.txt";
            // string recipientFile = "RecipientData.txt";
            //List<Donor> D = new List<Donor>();            
            // List<Recipient> R = new List<Recipient>();
            EmployeeCRUD.LoadEmployee();
            // LoadDonor(donorFile, D);
            // LoadRecipient(recipientFile, R);
            while (true)
            {
                Input.printHeader();
                int user = Input.login();
                if (user == 1)
                {
                    // calling admin interference
                    Input.printHeader();
                    adminMenu();
                }
                else if (user == 2)
                {
                    Input.printHeader();
                    Console.WriteLine("user");
                    Console.ReadKey();
                    // employeeMenu(donorFile, D, recipientFile, R);
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
                Input.printHeader();
                Input.menuName("Login", "Admin Menu");
                Input.printAMenu();                 // menu

                choice = choiceCheck();

                if (choice == 1)
                {
                    Input.printHeader();
                    Employee E = Input.addEmployee();
                    EmployeeCRUD.AddEmployeeToList(E);
                    EmployeeCRUD.EmployeeToFile(E);
                    Input.Back("Employee Added Successfully...");
                }
                if (choice == 2)
                {
                    Input.printHeader();
                    string name = Input.SearchEmployee("Admin Menu", "Delete Employee");
                    int idx = EmployeeCRUD.SearchEmployee(name);
                    if (idx != -1)
                    {
                        Input.Heading();
                        Input.DisplayEmployee(EmployeeCRUD.Employees[idx]);
                        EmployeeCRUD.DeleteEmployeeToList(EmployeeCRUD.Employees[idx]);
                        EmployeeCRUD.updateEmployeeFile();
                        Input.Back("Employee Removed...");
                    }
                    else
                    {
                        Input.Back("Employee Not Found");
                    }
                }
                if (choice == 3)
                {
                    Input.printHeader();
                    string name = Input.SearchEmployee("Admin Menu", "Update Employee");
                    int idx = EmployeeCRUD.SearchEmployee(name);
                    if (idx != -1)
                    {
                        Input.Heading();
                        Input.DisplayEmployee(EmployeeCRUD.Employees[idx]);
                        Employee update = Input.NewEmployee();
                        EmployeeCRUD.Employees[idx] = update;
                        EmployeeCRUD.updateEmployeeFile();
                        Input.Back("Employee Updated...");
                    }
                    else
                    {
                        Input.Back("Employee Not Found");
                    }
                }
                if (choice == 4)
                {
                    Input.printHeader();
                    string name = Input.SearchEmployee("Admin Menu", "Search Employee");
                    int idx = EmployeeCRUD.SearchEmployee(name);
                    if (idx != -1)
                    {
                        Input.Heading();
                        Input.DisplayEmployee(EmployeeCRUD.Employees[idx]);
                        Input.Back("");
                    }
                    else
                    {
                        Input.Back("Employee Not Found");
                    }
                }
                if (choice == 5)
                {
                    Input.printHeader();
                    Input.menuName("Admin Menu", "View all Employees");
                    Input.Heading();
                    if (EmployeeCRUD.Employees.Count != 0)
                    {
                        foreach (var E in EmployeeCRUD.Employees)
                        {
                            Input.DisplayEmployee(E);
                        }
                        Input.Back("");
                    }
                    else
                    {
                        Input.Back("Employees Not Found...Add First to View");
                    }
                }
            }
        }
        /*static void employeeMenu(string donorpath, List<Donor> D, string recipientpath, List<Recipient> R)
        {
            int choice = 0;
            while (choice != 10)
            {
                printHeader();
                Console.WriteLine();
                Console.WriteLine();
                string menu = "Login"; // submenu variables
                string subMenu = "Employee Menu";
                menuName(menu, subMenu);

                printEMenu();                 // menu

                choice = choiceCheck();

                if (choice == 1)
                {
                    printHeader();
                    addDonor(donorpath, D);
                }
                if (choice == 2)
                {
                    printHeader();
                    deleteDonor(donorpath, D);
                }
                if (choice == 3)
                {
                    printHeader();
                    updateDonor(donorpath, D);
                }
                if (choice == 4)
                {
                    printHeader();
                    searchDonor(D);
                }
                if (choice == 5)
                {
                    printHeader();
                    viewDonor(D);
                }
            }
        }*/

        /*static void addDonor(string path, List<Donor> D)
        {
            string name = "";
            string age = "";
            string BG = "";
            string city = "";
            string contact = "";
            string contributer = "";

            Console.WriteLine();
            string menu = "Employee Menu"; // submenu variables
            string subMenu = "Add Donor";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter Details of the New Donor:-");
            Console.WriteLine();
            Console.Write("Enter Name: ");
            name = isAlpha(name);

            Console.Write("Enter Age(+18): ");
            age = isNum(age);

            Console.Write("Enter Bloodgroup(13 numbers): ");
            BG = isBG(BG);

            Console.Write("Enter City: ");
            city = isAlpha(city);

            Console.Write("Enter Contact No(11 numbers): ");
            contact = contactCheck(contact);

            contributer = user;

            Donor D1 = new Donor(name, age, BG, city, contact, contributer);

            DonorToFile(path, D1); // to file

            D1.AddDonorToList(D, D1);


            Console.WriteLine();
            Console.WriteLine("Donor Added Sucessfully...");
            Thread.Sleep(300);
            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();
        }
        static void deleteDonor(string path, List<Donor> D)
        {
            string deleteName;
            Console.WriteLine();
            string menu = "Admin Menu"; // submenu variables
            string subMenu = "Delete Donor";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter Username of the Donor: ");
            deleteName = Console.ReadLine();
            Console.WriteLine();

            Donor D1 = SearchDonorIndex(deleteName, D);


            Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "BloodGroup".PadRight(20) + "City".PadRight(20) + "Contact No.".PadRight(20));
            Console.WriteLine();

            if (D1 != null)
            {
                DisplaySingleDonor(D1);
                D1.DeleteDonorToList(D, D1);
                updateDonorFile(path, D);

                Console.WriteLine();
                Console.WriteLine("Donor Removed...");
            }
            else if (D1 == null)
            {
                Console.WriteLine();
                Console.WriteLine("Donor Not Found");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();
        }
        static void updateDonor(string path, List<Donor> D)
        {
            string name = "";
            string age = "";
            string BG = "";
            string contact = "";
            string city = "";
            string contributer = "";

            string updateName;
            Console.WriteLine();
            string menu = "Employee Menu"; // submenu variables
            string subMenu = "Update Donor";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter name of the Donor: ");
            updateName = Console.ReadLine();
            Console.WriteLine();

            Donor D1 = SearchDonorIndex(updateName, D);

            Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "BloodGroup".PadRight(20) + "City".PadRight(20) + "Contact No.".PadRight(20));
            Console.WriteLine();

            if (D1 != null)
            {
                DisplaySingleDonor(D1);

                Console.WriteLine(); // update details

                Console.Write("Enter Name: ");
                name = isAlpha(name);

                Console.Write("Enter Age(+18): ");
                age = isNum(age);

                Console.Write("Enter Bloodgroup(13 numbers): ");
                BG = isBG(BG);

                Console.Write("Enter City: ");
                city = isAlpha(city);

                Console.Write("Enter Contact No(11 numbers): ");
                contact = contactCheck(contact);

                contributer = user;

                _ = new Donor(name, age, BG, city, contact, contributer);
                
                updateDonorFile(path, D);

                Console.WriteLine();
                Console.WriteLine("Donor Updated...");
            }
            else if (D1 == null)
            {
                Console.WriteLine();
                Console.WriteLine("Donor Not Found");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();

        }
        static void searchDonor(List<Donor> D)
        {
            string searchName;
            Console.WriteLine();
            string menu = "Employee Menu"; // submenu variables
            string subMenu = "Search Donor";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter username of the Donor: "); // username employee
            searchName = Console.ReadLine();

            Donor D1 = SearchDonorIndex(searchName, D);

            Console.WriteLine();
            Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "BloodGroup".PadRight(20) + "City".PadRight(20) + "Contact No.".PadRight(20));
            Console.WriteLine();

            if (D1 != null)
            {
                DisplaySingleDonor(D1);
            }
            else if (D1 == null)
            {
                Console.WriteLine();
                Console.WriteLine("Donor Not Found");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();

        }
        static void viewDonor(List<Donor> D)
        {
            Console.WriteLine();
            string menu = "Employee Menu"; // submenu variables
            string subMenu = "View All Donor";
            menuName(menu, subMenu);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Following Are the Donors: ");
            Console.WriteLine();

            Console.WriteLine("Name".PadRight(20) + "Age".PadRight(20) + "BloodGroup".PadRight(20) + "City".PadRight(20) + "Contact No.".PadRight(20));
            Console.WriteLine(); // display all

            for (int idx = 0; idx < D.Count; idx++)
            {
                DisplaySingleDonor(D[idx]);
            }

            if (D.Count == 0)
            {
                Console.WriteLine("Donor not Found");
                Console.WriteLine("Add Donor to View Donors");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key for back...");
            Console.ReadKey();
        }*/

        /*static void LoadDonor(string path, List<Donor> D)
        {
            StreamReader donorData = new StreamReader(path);
            string line = "";
            while ((line = donorData.ReadLine()) != null)
            {
                if (line != "")
                {
                    string name = Dataparse(line, 1);

                    string age = Dataparse(line, 2);

                    string bloodgroup = Dataparse(line, 3);

                    string city = Dataparse(line, 4);

                    string contact = Dataparse(line, 5);

                    string contributer = Dataparse(line, 6);

                    Donor D1 = new Donor(name, age, bloodgroup, city, contact, contributer);
                    D1.AddDonorToList(D, D1);
                }
            }
            donorData.Close();
        }
        static void LoadRecipient(string path, List<Recipient> R)
        {
            StreamReader recipientData = new StreamReader(path);
            string line = "";
            while ((line = recipientData.ReadLine()) != null)
            {
                if (line != "")
                {
                    string name = Dataparse(line, 1);

                    string age = Dataparse(line, 2);

                    string bloodgroup = Dataparse(line, 3);

                    string city = Dataparse(line, 4);

                    string contact = Dataparse(line, 5);

                    string contributer = Dataparse(line, 6);

                    Recipient R1 = new Recipient(name, age, bloodgroup, city, contact, contributer);
                    R1.AddRecipientToList(R, R1);
                }
            }
            recipientData.Close();
        }*/

        /*static void DonorToFile(string path, Donor D)
        {
            StreamWriter donorData = new StreamWriter(path, true);
            donorData.WriteLine(D.nameD + "," + D.ageD + "," + D.bloodgroupD + "," + D.cityD + "," + D.contactD + "," + D.contributerD);
            donorData.Flush();
            donorData.Close();
        }
        static void RecipientToFile(string path, Recipient R)
        {
            StreamWriter recipientData = new StreamWriter(path, true);
            recipientData.WriteLine(R.nameR + "," + R.ageR + "," + R.bloodgroupR + "," + R.cityR + "," + R.contactR + "," + R.contributerR);
            recipientData.Flush();
            recipientData.Close();
        }*/

        /*static void updateDonorFile(string path, List<Donor> D)
        {
            StreamWriter donorData = new StreamWriter(path);
            for (int i = 0; i < D.Count; i++)
            {
                if (D[i].nameD != "")
                {
                    donorData.WriteLine(D[i].nameD + "," + D[i].ageD + "," + D[i].bloodgroupD + "," + D[i].cityD + "," + D[i].contactD + "," + D[i].contributerD);
                }
            }
            donorData.Flush();
            donorData.Close();
        }
        static void updateRecipientFile(string path, List<Recipient> R)
        {
            StreamWriter recipientData = new StreamWriter(path);
            for (int i = 0; i < R.Count; i++)
            {
                if (R[i].nameR != "")
                {
                    recipientData.WriteLine(R[i].nameR + "," + R[i].ageR + "," + R[i].bloodgroupR + "," + R[i].cityR + "," + R[i].contactR + "," + R[i].contributerR);
                }
            }
            recipientData.Flush();
            recipientData.Close();
        }*/

        /*static Donor SearchDonorIndex(string name, List<Donor> D)
        {
            Donor D1 = null;

            for (int idx = 0; idx < D.Count; idx++)
            {
                if (name == D[idx].nameD)
                {
                    D1 = D[idx];
                    break;
                }
            }
            return D1;
        }
        static Recipient SearchRecipientIndex(string name, List<Recipient> R)
        {
            Recipient R1 = null;

            for (int idx = 0; idx < R.Count; idx++)
            {
                if (name == R[idx].nameR)
                {
                    R1 = R[idx];
                    break;
                }
            }
            return R1;
        }*/
        /*static void DisplaySingleDonor(Donor D)
        {
            Console.WriteLine(D.nameD.PadRight(20) + D.ageD.PadRight(20) + D.bloodgroupD.PadRight(20) + D.cityD.PadRight(20) + D.contactD.PadRight(20));
        }
        static void DisplaySingleRecipient(Recipient R)
        {
            Console.WriteLine(R.nameR.PadRight(20) + R.ageR.PadRight(20) + R.bloodgroupR.PadRight(20) + R.cityR.PadRight(20) + R.contactR.PadRight(20));
        }*/
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
        /*static string isBG(string input)
        {
            input = Console.ReadLine();
            while (true)
            {
                if (input == "A+" || input == "A-" || input == "B+" || input == "B-" || input == "AB+" || input == "AB-" || input == "O+" || input == "O-")
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
        }*/
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
