using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int side = 1;

        private void label1_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label.Text == "" && label.BackColor == Color.Silver && side == 2)
            {
                label241.ForeColor = Color.Green;
                label242.ForeColor = Color.Red;
                if (label.Tag == "X")
                    label.BackColor = Color.Red;
                else
                    label.Text = "X";
                side = 1;
            }
        }

        private void label1r_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label.Text == "" && label.BackColor == Color.Silver && side == 1)
            {
                label241.ForeColor = Color.Red;
                label242.ForeColor = Color.Green;
                if (label.Tag == "X")
                    label.BackColor = Color.Red;
                else
                    label.Text = "X";
                side = 2;
            }
        }
    }
}
