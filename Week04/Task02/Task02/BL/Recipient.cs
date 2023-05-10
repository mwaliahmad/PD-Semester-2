using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.BL
{
    public class Recipient
    {
        public Recipient(string nameR, string ageR, string bloodgroupR, string cityR, string contactR, string contributerR)
        {
            this.nameR = nameR;
            this.ageR = ageR;
            this.bloodgroupR = bloodgroupR;
            this.cityR = cityR;
            this.contactR = contactR;
            this.contributerR = contributerR;
        }
        public string nameR;
        public string ageR;
        public string bloodgroupR;
        public string cityR;
        public string contactR;
        public string contributerR;
        public string GetContributer()
        {
            return contributerR;
        }
        public void AddRecipientToList(List<Recipient> R, Recipient R1)
        {
            R.Add(R1);
        }
        public void DeleteDonorToList(List<Recipient> R, Recipient R1)
        {
            R.Remove(R1);
        }
    }
}
