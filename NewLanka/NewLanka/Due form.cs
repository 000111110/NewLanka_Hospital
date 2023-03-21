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
    public partial class Due_form : Form
    {
        public Due_form()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into due values(@dueid,@totalamount,@firstdue,@firstduedate,@seconddue,@secondduedate,@thirddue,@thirdduedate,@balance)", con);
            cmd.Parameters.AddWithValue("@dueid", textBox1.Text);
            cmd.Parameters.AddWithValue("@totalamount", textBox2.Text);
            cmd.Parameters.AddWithValue("@firstdue", textBox3.Text);
            cmd.Parameters.AddWithValue("@firstduedate", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@seconddue", textBox4.Text);
            cmd.Parameters.AddWithValue("@secondduedate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue("@thirddue",textBox5.Text);
            cmd.Parameters.AddWithValue("@thirdduedate", DateTime.Parse(dateTimePicker3.Text));
            cmd.Parameters.AddWithValue("@balance", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Due details Added");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update due set totalamount=@totalamount,firstdue=@firstdue,firstduedate=@firstduedate,seconddue=@seconddue,secondduedate=@secondduedate,thirddue=@thirddue,thirdduedatedate=@thirdduedatedate,balance=@balance where dueid=@dueid", con);
            cmd.Parameters.AddWithValue("@dueid", textBox1.Text);
            cmd.Parameters.AddWithValue("@totalamount", textBox2.Text);
            cmd.Parameters.AddWithValue("@firstdue", textBox3.Text);
            cmd.Parameters.AddWithValue("@firstduedate", DateTime.Parse(dateTimePicker1.Text));
            cmd.Parameters.AddWithValue("@seconddue", textBox4.Text);
            cmd.Parameters.AddWithValue("@secondduedate", DateTime.Parse(dateTimePicker2.Text));
            cmd.Parameters.AddWithValue(",@thirddue", textBox5.Text);
            cmd.Parameters.AddWithValue("@thirdduedatedate", DateTime.Parse(dateTimePicker3.Text));
            cmd.Parameters.AddWithValue(",@balance", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Due Updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-39MKE60\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from due", con);
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
            dateTimePicker2.Text = null;
            textBox5.Clear();
            dateTimePicker3.Text = null;
            textBox6.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
