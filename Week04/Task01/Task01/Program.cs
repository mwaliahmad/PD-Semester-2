using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.BL;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            int choice;
            do
            {
                choice = Menu();
                if (choice == 1)
                {
                    Console.Clear();
                    Ship S = UserInput();
                    S.AddShip(ships, S);
                    Back();
                }
                else if (choice == 2)
                {
                    Console.Clear();
                    SearchShipByNumber(ships);
                    Back();
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    SearchShipByAngle(ships);
                    Back();
                }
                else if (choice == 4)
                {
                    Console.Clear();
                    ChangeShipByNumber(ships);
                    Back();
                }
                else if (choice > 5)
                {
                    Console.WriteLine("Wrong Input");
                }
            }
            while (choice != 5);
            Console.WriteLine();
            Console.WriteLine("Press Any Key for Exit");
            Console.ReadKey();
        }
        static int Menu()
        {
            Console.Clear();

            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");

            Console.Write("Enter Option: ");
            int opt = int.Parse(Console.ReadLine());
            return opt;
        }
        static Ship UserInput()
        {
            string serialNumber;

            int Longitudedegree;
            float Longitudeminutes;
            char Longitudedirection;

            int Latitudedegree;
            float Latitudeminutes;
            char Latitudedirection;

            Console.Write("Enter Serial Number: ");
            serialNumber = Console.ReadLine();

            Console.WriteLine("Enter Ship Latitude: ");
            Console.Write("Enter Ship Latitude 's Degree: ");
            Latitudedegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Ship Latitude 's Minutes: ");
            Latitudeminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Ship Latitude 's Direction: ");
            Latitudedirection = char.Parse(Console.ReadLine());

            Angle Latitude = new Angle(Latitudedegree, Latitudeminutes, Latitudedirection);

            Console.WriteLine("Enter Ship Longitude: ");
            Console.Write("Enter Ship Longitude 's Degree: ");
            Longitudedegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Ship Longitude 's Minutes: ");
            Longitudeminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Ship Longitude 's Direction: ");
            Longitudedirection = char.Parse(Console.ReadLine());

            Angle Longitude = new Angle(Longitudedegree, Longitudeminutes, Longitudedirection);

            Ship S = new Ship(serialNumber, Latitude, Longitude);
            return S;
        }
        static void SearchShipByNumber(List<Ship> ships)
        {
            Console.Write("Enter Ship Serial Number: ");
            string number = Console.ReadLine();
            Ship S = SearchShipByNumber(number, ships);
            string angle1 = S.GetLatitude();
            string angle2 = S.GetLongitude();

            Console.WriteLine("Ship is at {0} and {1} ", angle1, angle2);
        }
        static Ship SearchShipByNumber(string name, List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                if (ship.number == name)
                {
                    return ship;
                }
            }
            return null;
        }
        static void Back()
        {
            Console.WriteLine();
            Console.WriteLine("Press Any Key For Back...");
            Console.ReadKey();
        }
        static void SearchShipByAngle(List<Ship> ships)
        {
            int Longitudedegree;
            float Longitudeminutes;
            char Longitudedirection;

            int Latitudedegree;
            float Latitudeminutes;
            char Latitudedirection;

            Console.WriteLine("Enter Ship Latitude: ");
            Console.Write("Enter Ship Latitude 's Degree: ");
            Latitudedegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Ship Latitude 's Minutes: ");
            Latitudeminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Ship Latitude 's Direction: ");
            Latitudedirection = char.Parse(Console.ReadLine());

            Angle Latitude = new Angle(Latitudedegree, Latitudeminutes, Latitudedirection);

            Console.WriteLine("Enter Ship Longitude: ");
            Console.Write("Enter Ship Longitude 's Degree: ");
            Longitudedegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Ship Longitude 's Minutes: ");
            Longitudeminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Ship Longitude 's Direction: ");
            Longitudedirection = char.Parse(Console.ReadLine());

            Angle Longitude = new Angle(Longitudedegree, Longitudeminutes, Longitudedirection);

            Ship S = SearchShipByAngle(Latitude, Longitude, ships);

            string serial = S.SerialNumber();
            Console.WriteLine("Serial Number of the Ship is {0}", serial);
        }
        static Ship SearchShipByAngle(Angle Latitude, Angle Longitude, List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                if (ship.GetLatitude() == Latitude.GetAngle() && ship.Longitude.GetAngle() == Longitude.GetAngle())
                {
                    return ship;
                }
            }
            return null;
        }
        static void ChangeShipByNumber(List<Ship> ships)
        {
            Console.Write("Enter Ship Serial Number: ");
            string number = Console.ReadLine();

            Ship S = SearchShipByNumber(number, ships);

            int Longitudedegree;
            float Longitudeminutes;
            char Longitudedirection;

            int Latitudedegree;
            float Latitudeminutes;
            char Latitudedirection;

            Console.WriteLine("Enter Ship Latitude: ");
            Console.Write("Enter Ship Latitude 's Degree: ");
            Latitudedegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Ship Latitude 's Minutes: ");
            Latitudeminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Ship Latitude 's Direction: ");
            Latitudedirection = char.Parse(Console.ReadLine());

            S.Latitude = new Angle(Latitudedegree, Latitudeminutes, Latitudedirection);

            Console.WriteLine("Enter Ship Longitude: ");
            Console.Write("Enter Ship Longitude 's Degree: ");
            Longitudedegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Ship Longitude 's Minutes: ");
            Longitudeminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Ship Longitude 's Direction: ");
            Longitudedirection = char.Parse(Console.ReadLine());

            S.Longitude = new Angle(Longitudedegree, Longitudeminutes, Longitudedirection);
        }
    }
}
