using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem02.BL;
using System.IO;
namespace Problem02.DL
{
   public class UserCRUD
    {
        private static List<User> users = new List<User>()
        {
            new User("a", "b", "c"),
            new User("d", "e", "f"),
            new User("g", "h", "i"),
            new User("j", "k", "l")
        };

        public static List<User> Users { get => users; set => users = value; }

        public static void AddUserToList(User U)
        {
            Users.Add(U);
        }
        public static void Delete(int i)
        {
            Users.RemoveAt(i);
        }
        public static bool SearchUser(string Username)
        {
            foreach(var o in Users)
            {
                if(Username==o.GetUsername())
                {
                    return true;
                }
            }
            return false;
        }
        public static User UserSignIn(User U)
        {
            foreach (var user in Users)
            {
                if (user.GetUsername() == U.GetUsername() && user.GetPassword() == U.GetPassword())
                {
                    return user;
                }
            }
            return null;
        }
        public static string ParseData(string line, int field)
        {
            int comma = 1;
            string item = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + line[i];
                }
            }
            return item;
        }
        public static bool LoadData(string path)
        {
            if (File.Exists(path))
            {
                StreamReader data = new StreamReader(path);
                string record;
                while ((record = data.ReadLine()) != null)
                {
                    string name = ParseData(record, 1);
                    string pass = ParseData(record, 2);
                    string role = ParseData(record, 3);
                    User U = new User(name, pass, role);
                    AddUserToList(U);
                }
                data.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void DatatoFile(User U, string path)
        {
            StreamWriter data = new StreamWriter(path, true);
            data.WriteLine(U.GetUsername() + "," + U.GetPassword() + "," + U.GetRole());
            data.Flush();
            data.Close();
        }

    }
}
