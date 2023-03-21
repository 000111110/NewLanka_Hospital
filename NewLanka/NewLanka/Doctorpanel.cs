﻿using System;
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
    public partial class Doctorpanel : Form
    {
        public Doctorpanel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patientform pform = new Patientform();
            pform.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Medicinesdetails meddet = new Medicinesdetails();
            meddet.Show();
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Paymentform payform = new Paymentform();
            payform.Show();
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MLogin lgin = new MLogin();
            lgin.Show();
            Visible = false;
        }
    }
}
