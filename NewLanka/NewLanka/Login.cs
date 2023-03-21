using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewLanka
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MLogin dlgin = new MLogin();
            dlgin.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NurseLogin nlgin = new NurseLogin();
            nlgin.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            Visible = false;
        }
    }
}
