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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NewLanka
{
    public partial class Doctorsform : Form
    {
        public Doctorsform()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Nursepanel npanel = new Nursepanel();
            npanel.Show();
            Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into doctor values(@doctorid,@fullname,@specalisation,@gender, @dob,@mobilenumber,@address)", con);
            cmd.Parameters.AddWithValue("@doctorid", textBox1.Text);
            cmd.Parameters.AddWithValue("@fullname", textBox2.Text);
            cmd.Parameters.AddWithValue("@specalisation", comboBox1.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
            cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@mobilenumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Doctor Record Added Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update doctor set fullname=@fullname,specalisation=@specalisation,gender=@gender, dob=@dob,mobilenumber=@mobilenumber,address=@address where doctorid=@doctorid", con);
            cmd.Parameters.AddWithValue("@doctorid", textBox1.Text);
            cmd.Parameters.AddWithValue("@fullname", textBox2.Text);
            cmd.Parameters.AddWithValue("@specalisation", comboBox1.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox2.Text);
            cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@mobilenumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Doctor Record Updated Successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete doctor where doctorid=@doctorid", con);
            cmd.Parameters.AddWithValue("@doctorid", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Doctor Record Deleted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from doctor", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Text = null;
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
