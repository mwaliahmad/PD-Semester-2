using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.BL
{
    public class Ship
    {
        public Ship(string number, Angle Latitude, Angle Longitude)
        {
            this.number = number;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
        public string number;
        public Angle Longitude;
        public Angle Latitude;

        public void AddShip(List<Ship> ships, Ship S)
        {
            ships.Add(S);
        }
        public string GetLatitude()
        {
            return Latitude.GetAngle();
        }
        public string GetLongitude()
        {
            return Longitude.GetAngle();
        }
        public string SerialNumber()
        {
            return this.number;
        }
    }
}
