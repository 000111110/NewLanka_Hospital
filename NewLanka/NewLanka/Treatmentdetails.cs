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
    public partial class Treatmentdetails : Form
    {
        public Treatmentdetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Treatmentdetails_Load(object sender, EventArgs e)
        {

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
            SqlCommand cmd = new SqlCommand("insert into treatments values(@treatment,@doctorid,@patientid,@nomedicines,@test)", con);
            cmd.Parameters.AddWithValue("@treatment", textBox1.Text);
            cmd.Parameters.AddWithValue("@doctorid", textBox2.Text);
            cmd.Parameters.AddWithValue("@patientid", textBox3.Text);
            cmd.Parameters.AddWithValue("@nomedicines",textBox4.Text);
            cmd.Parameters.AddWithValue("@test", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Treatment Added");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update treatments set doctorid=@doctorid,patientid=@patientid,nomedicines=@nomedicines,test=@test where treatment=@treatment", con);
            cmd.Parameters.AddWithValue("@treatment", textBox1.Text);
            cmd.Parameters.AddWithValue("@doctorid", textBox2.Text);
            cmd.Parameters.AddWithValue("@patientid", textBox3.Text);
            cmd.Parameters.AddWithValue("@nomedicines", textBox4.Text);
            cmd.Parameters.AddWithValue("@test", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Treatment Record Updated");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete treatments where treatment=@treatment", con);
            cmd.Parameters.AddWithValue("@treatment", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("treatment Record Deleted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from treatments", con);
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
            comboBox1.Text = "";
        }
    }
}
