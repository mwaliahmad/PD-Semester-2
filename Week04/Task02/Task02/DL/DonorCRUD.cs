using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02.BL;

namespace Task02.DL
{
    public class DonorCRUD
    {
        public static List<Donor> Donors = new List<Donor>();
        static string DonorFile = "Donor.txt";
        public static void AddDonorToList(Donor D1)
        {
            Donors.Add(D1);
        }
        public static void DeleteDonorToList(Donor D1)
        {
            Donors.Remove(D1);
        }
        public static int SearchDonor(string BG)
        {
            int index = -1;

            for (int idx = 0; idx < Donors.Count; idx++)
            {
                if (BG == Donors[idx].bloodgroupD)
                {
                    index = idx;
                    break;
                }
            }
            return index;
        }
    }
}
