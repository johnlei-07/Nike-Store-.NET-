using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NikeStore
{
    public partial class shoes : Form
    {
        public shoes()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Buttoms b = new Buttoms();
            b.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            tops t = new tops();
            t.Show();
            this.Hide();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            jersey j = new jersey();
            j.Show();
            this.Hide();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_buynow_Click(object sender, EventArgs e)
        {

        }
    }
}
