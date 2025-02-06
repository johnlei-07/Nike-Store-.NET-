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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            tops t = new tops();
            t.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Buttoms b = new Buttoms();
            b.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            shoes s = new shoes();
            s.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            jersey j = new jersey();
            j.Show();
            this.Hide();
        }
    }
}
