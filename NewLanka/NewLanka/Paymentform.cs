using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewLanka
{
    public partial class Paymentform : Form
    {
        public Paymentform()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Nursepanel npanel = new Nursepanel();
            npanel.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into due values(@dueid,@patientid,@hospitalcharge,@doctorcharge,@medicinecharge,@testingcharge,@totalcharge,@date)", con);
            cmd.Parameters.AddWithValue("@paymentid", textBox1.Text);
            cmd.Parameters.AddWithValue("@patientid", textBox2.Text);
            cmd.Parameters.AddWithValue("@hospitalcharge", textBox3.Text);
            cmd.Parameters.AddWithValue("@doctorcharge", textBox4.Text);
            cmd.Parameters.AddWithValue("@medicinecharge", textBox5.Text);
            cmd.Parameters.AddWithValue("@testingcharge", textBox6.Text);
            cmd.Parameters.AddWithValue("@totalcharge", textBox7.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Payment Added");
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update payment set patientid=@patientid,hospitalcharge=@hospitalcharge,doctorcharge=@doctorcharge,medicinecharge=@medicinecharge,testingcharge=@testingcharge,totalcharge=@totalcharge,date=@date where paymentid=@paymentid",con);
            cmd.Parameters.AddWithValue("@paymentid", textBox1.Text);
            cmd.Parameters.AddWithValue("@patientid", textBox2.Text);
            cmd.Parameters.AddWithValue("@hospitalcharge", textBox3.Text);
            cmd.Parameters.AddWithValue("@doctorcharge", textBox4.Text);
            cmd.Parameters.AddWithValue("@medicinecharge", textBox5.Text);
            cmd.Parameters.AddWithValue("@testingcharge", textBox6.Text);
            cmd.Parameters.AddWithValue("@totalcharge", textBox7.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Payment Details Updated");
        }

        private void button6_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete payment where paymentid=@paymentid", con);
            cmd.Parameters.AddWithValue("@paymentid", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Payment Record Deleted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from payment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            dateTimePicker1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Due_form dueform = new Due_form();
            dueform.Show();
            Visible = false;
        }
    }
}
