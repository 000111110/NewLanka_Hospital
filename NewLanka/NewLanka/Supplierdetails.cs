using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NewLanka
{
    public partial class Supplierdetails : Form
    {
        
        public Supplierdetails()
        {
            InitializeComponent();
        }

        private void Supplierdetails_Load(object sender, EventArgs e)
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
            SqlCommand cmd = new SqlCommand("insert into supplier values(@supplierid,@companyname,@mobilenumber,@address, @ownername)", con);
            cmd.Parameters.AddWithValue("@supplierid", textBox1.Text);
            cmd.Parameters.AddWithValue("@companyname", textBox2.Text);
            cmd.Parameters.AddWithValue("@mobilenumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);
            cmd.Parameters.AddWithValue("@ownername", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Supplier Record Added Successfully");
        }
         public void showdata()
        {
        
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update supplier set ownername=@ownername, address=@address, mobilenumber=@mobilenumber,companyname=@companyname where supplierid=@supplierid", con);
            cmd.Parameters.AddWithValue("@supplierid", textBox1.Text);
            cmd.Parameters.AddWithValue("@companyname", textBox2.Text);
            cmd.Parameters.AddWithValue("@mobilenumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);
            cmd.Parameters.AddWithValue("@ownername", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Supplier Record updated Successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete supplier where supplierid=@supplierid", con);
            cmd.Parameters.AddWithValue("@supplierid", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Supplier Record Deleted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from supplier", con);
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
        }
    }
}
