using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Problem02.DL;
using Problem02.BL;
namespace Problem02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            databind();
        }
        private void databind()
        {
/*          User U1 = new User("a", "b", "c");
            User U2 = new User("d", "e", "f");
            User U3 = new User("g", "h", "i");
            User U4 = new User("j", "k", "l");
            UserCRUD.Users.Add(U1);
            UserCRUD.Users.Add(U2);
            UserCRUD.Users.Add(U3);
            UserCRUD.Users.Add(U4);*/
            gv.DataSource = null;
            gv.DataSource = UserCRUD.Users;
            gv.Refresh();
        }

        private void gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            DeleteUser();
            databind();


        }
        private void DeleteUser()
        {
            int idx = gv.SelectedCells[0].RowIndex;
            UserCRUD.Delete(idx);
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            if (UserCRUD.SearchUser(textBox1.Text))
            {
                MessageBox.Show("Exist");
            }
            else
            {
                MessageBox.Show("Not Exist");
            }
        }
    }
}
