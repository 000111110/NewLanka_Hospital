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
    public partial class Medicinesdetails : Form
    {
        public Medicinesdetails()
        {
            InitializeComponent();
        }

        private void Medicinesdetails_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Nursepanel npanel = new Nursepanel();
            npanel.Show();
            Visible = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into medicine values(@medicineid,@medicinename,@companyname,@manufacturedate,@expiredate,@price,@supplierid)", con);
            cmd.Parameters.AddWithValue("@medicineid", textBox1.Text);
            cmd.Parameters.AddWithValue("@medicinename", textBox2.Text);
            cmd.Parameters.AddWithValue("@companyname", textBox3.Text);
            cmd.Parameters.AddWithValue("@manufacturedate", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@expiredate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@price", textBox4.Text);
            cmd.Parameters.AddWithValue("@supplierid", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Medicines Record Added Successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update medicine set medicinename=@medicinename,companyname=@companyname,manufacturedate=@manufacturedate,expiredate=@expiredate,price=@price,supplierid=@supplierid where medicineid=@medicineid", con);
            cmd.Parameters.AddWithValue("@medicineid", textBox1.Text);
            cmd.Parameters.AddWithValue("@medicinename", textBox2.Text);
            cmd.Parameters.AddWithValue("@companyname", textBox3.Text);
            cmd.Parameters.AddWithValue("@manufacturedate", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@expiredate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@price", textBox4.Text);
            cmd.Parameters.AddWithValue("@supplierid", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Medicines Record Updated Successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete medicine where medicineid=@medicineid", con);
            cmd.Parameters.AddWithValue("@medicineid", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Medicines Record Deleted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from medicine", con);
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
            dateTimePicker2.Text = null;
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
