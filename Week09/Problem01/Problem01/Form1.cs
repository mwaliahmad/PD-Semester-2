using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<string> lst = new List<string>() { "Press", "text1", "text2", "text3", "text4", "text5" };
            databind(lst);
        }
        private void databind(List<string> lst)
        {
            cb1.DataSource = null;
            cb1.DataSource = lst;
            cb1.Refresh();
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt1.Text = cb1.SelectedItem.ToString();
            if (cb1.SelectedIndex == 0)
                txt1.Text = null;
                    }

        private void Form1_Load(object sender, EventArgs e)
        {/*
            cb1.SelectedIndex = 0;*/
            txt1.Text = null;
        }
    }
}
