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
    public partial class MLogin : Form
    {
        public MLogin()
        {
            InitializeComponent();
        }

        private void DoctorLogin_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=NewLankaHospital;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from login where username='" + txtuser.Text + "' and password='" +txtpass.Text+ "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);          
            DataTable dt = new DataTable();     
            sda.Fill(dt);   
            string cmbItemValue=comboBox1.SelectedItem.ToString();
            if( dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if(dt.Rows[i]["usertype"].ToString()==cmbItemValue)
                    {
                        MessageBox.Show("You are login as "+dt.Rows[i][2]);
                        if (comboBox1.SelectedIndex==0)
                        {
                         Nursepanel n = new Nursepanel();
                            n.Show();
                            this.Hide();
                        }
                        
                        else if (comboBox1.SelectedIndex==1)
                        {
                         Doctorpanel d = new Doctorpanel();     
                            d.Show();
                            this.Hide();
                        }
                    }
                }
                }
            else
            {
                MessageBox.Show("username or password error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpass.Clear();
            comboBox1.Text = "";
        }
    }
}
