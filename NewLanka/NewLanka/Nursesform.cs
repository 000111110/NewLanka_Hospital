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

namespace NewLanka
{
    public partial class Nursesform : Form
    {
        public Nursesform()
        {
            InitializeComponent();
        }
                          
        private void label12_Click(object sender, EventArgs e)
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
            SqlCommand cmd = new SqlCommand("insert into nurse values(@nurseid,@firstname,@lastname,@gender, @dateofbirth,@mobilenumber,@address)",con);
            cmd.Parameters.AddWithValue("@nurseid",textBox1.Text);
            cmd.Parameters.AddWithValue("@firstname", textBox2.Text);
            cmd.Parameters.AddWithValue("@lastname", textBox3.Text);
            cmd.Parameters.AddWithValue("@gender",comboBox1.Text);
            cmd.Parameters.AddWithValue("@dateofbirth",DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@mobilenumber", textBox4.Text);
            cmd.Parameters.AddWithValue("@address", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Nurse Record Added Successfully");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update nurse set firstname=@firstname,lastname=@lastname,gender=@gender, dateofbirth=@dateofbirth,mobilenumber=@mobilenumber,address=@address where nurseid=@nurseid", con);
            cmd.Parameters.AddWithValue("@nurseid", textBox1.Text);
            cmd.Parameters.AddWithValue("@firstname", textBox2.Text);
            cmd.Parameters.AddWithValue("@lastname", textBox3.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@dateofbirth", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@mobilenumber", textBox4.Text);
            cmd.Parameters.AddWithValue("@address", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Nurse Record Updated Successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete nurse where nurseid=@nurseid",con);
            cmd.Parameters.AddWithValue("@nurseid", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Nurse Record Deleted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from nurse",con);
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
            comboBox1.Text="";
            dateTimePicker1.Text=null;
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
