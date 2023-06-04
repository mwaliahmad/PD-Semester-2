using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.BL
{
    public class Donor
    {
        public Donor(string ID, string nameD, string ageD, string bloodgroupD, string cityD, string contactD, string contributerD)
        {
            this.ID = ID;
            this.nameD = nameD;
            this.ageD = ageD;
            this.bloodgroupD = bloodgroupD;
            this.cityD = cityD;
            this.contactD = contactD;
            this.contributerD = contributerD;
        }
        public string ID;
        public string nameD;
        public string ageD;
        public string bloodgroupD;
        public string cityD;
        public string contactD;
        public string contributerD;

        public string GetContributer()
        {
            return contributerD;
        }
        public void AddDonorToList(List<Donor> D, Donor D1)
        {
            D.Add(D1);
        }
        public void DeleteDonorToList(List<Donor> D, Donor D1)
        {
            D.Remove(D1);
        }
    }
}
