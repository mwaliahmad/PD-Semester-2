using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task02.BL;

namespace Task02.DL
{
    class EmployeeCRUD
    {
        public static List<Employee> Employees = new List<Employee>();
        static string employeeFile = "Employee.txt";
        public static int SearchEmployee(string name)
        {
            int index = -1;

            for (int idx = 0; idx < Employees.Count; idx++)
            {
                if (name == Employees[idx].usernameE)
                {
                    index = idx;
                    break;
                }
            }
            return index;
        }
        public static void AddEmployeeToList(Employee E1)
        {
            Employees.Add(E1);
        }
        public static void DeleteEmployeeToList(Employee E1)
        {
            Employees.Remove(E1);
        }
        public static void LoadEmployee()
        {
            StreamReader employeeData = new StreamReader(employeeFile);
            string line = "";
            while ((line = employeeData.ReadLine()) != null)
            {
                if (line != "")
                {
                    string[] data = line.Split(',');
                    string name = data[0];

                    string age = data[1];

                    string cnic = data[2];

                    string contact = data[3];

                    string username = data[4];

                    string password = data[5];

                    Employee E1 = new Employee(name, age, contact, cnic, username, password);
                    AddEmployeeToList(E1);
                }
            }
            employeeData.Close();
        }
        public static void EmployeeToFile(Employee E)
        {
            StreamWriter employeeData = new StreamWriter(employeeFile, true);
            employeeData.WriteLine(E.nameE + "," + E.ageE + "," + E.cnicE + "," + E.contactE + "," + E.usernameE + "," + E.passwordE);
            employeeData.Flush();
            employeeData.Close();
        }
        public static void updateEmployeeFile()
        {
            StreamWriter employeeData = new StreamWriter(employeeFile);
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].nameE != "")
                {
                    employeeData.WriteLine(Employees[i].nameE + "," + Employees[i].ageE + "," + Employees[i].cnicE + "," + Employees[i].contactE + "," + Employees[i].usernameE + "," + Employees[i].passwordE);
                }
            }
            employeeData.Flush();
            employeeData.Close();
        }
    }
}
