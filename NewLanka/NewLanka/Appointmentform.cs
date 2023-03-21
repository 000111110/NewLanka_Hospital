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
    public partial class Appointmentform : Form
    {
        public Appointmentform()
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
            SqlCommand cmd = new SqlCommand("insert into appointments values(@appointmentid,@patientid,@doctorid,@date,@time)", con);
            cmd.Parameters.AddWithValue("@appointmentid", textBox1.Text);
            cmd.Parameters.AddWithValue("@patientid", textBox2.Text);
            cmd.Parameters.AddWithValue("@doctorid", textBox3.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@time", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Appointment Recorded");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update appointments set patientid=@patientid,doctorid=@doctorid,date=@date,time=@time where appointmentid=@appointmentid",con);
            cmd.Parameters.AddWithValue("@appointmentid", textBox1.Text);
            cmd.Parameters.AddWithValue("@patientid", textBox2.Text);
            cmd.Parameters.AddWithValue("@doctorid", textBox3.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@time", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Appointment Record Updated");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete appointments where appointmentid=@appointmentid", con);
            cmd.Parameters.AddWithValue("@appointmentid", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Appointment Deleted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from appointments", con);
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
            comboBox1.Text = "";
        }
    }
}
