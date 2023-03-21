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
    public partial class Patientform : Form
    {
        public Patientform()
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
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update patient set fullname=@fullname,nicnumber=@nicnumber,dob=@dob,age=@age,address=@address,gender=@gender,phonenumber=@phonenumber,guardianname=@guardianname,bloodgroup=@bloodgroup,weight=@weight,height=@height where patientid=@patientid", con);
            cmd.Parameters.AddWithValue("@patientid", textBox1.Text);
            cmd.Parameters.AddWithValue("@fullname", textBox2.Text);
            cmd.Parameters.AddWithValue("@nicnumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@age", textBox4.Text);
            cmd.Parameters.AddWithValue("@address", textBox5.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@phonenumber", textBox6.Text);
            cmd.Parameters.AddWithValue("@guardianname", textBox7.Text);
            cmd.Parameters.AddWithValue("@bloodgroup", comboBox2.Text);
            cmd.Parameters.AddWithValue("@weight", textBox8.Text);
            cmd.Parameters.AddWithValue("@height", textBox9.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Patient Record Updated Successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into patient values(@patientid,@fullname,@nicnumber,@dob,@age,@address,@gender,@phonenumber,@guardianname,@bloodgroup,@weight,@height)", con);
            cmd.Parameters.AddWithValue("@patientid", textBox1.Text);
            cmd.Parameters.AddWithValue("@fullname", textBox2.Text);
            cmd.Parameters.AddWithValue("@nicnumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@age", textBox4.Text);
            cmd.Parameters.AddWithValue("@address", textBox5.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@phonenumber", textBox6.Text);
            cmd.Parameters.AddWithValue("@guardianname", textBox7.Text);
            cmd.Parameters.AddWithValue("@bloodgroup", comboBox2.Text);
            cmd.Parameters.AddWithValue("@weight", textBox8.Text);

            cmd.Parameters.AddWithValue("@height", textBox9.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Patient Record Added Successfully");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete patient where patientid=@patientid", con);
            cmd.Parameters.AddWithValue("@patientid", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Patient Record Deleted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from patient", con);
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
            dateTimePicker1.Text = null;
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
            textBox6.Clear();
            textBox7.Clear();
            comboBox2.Text = "";
            textBox8.Clear();
            textBox9.Clear();

        }
    }
}
