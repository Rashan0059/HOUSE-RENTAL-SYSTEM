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

namespace AD_Project
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-RPMF38K;Initial Catalog=welcom" +
            ";Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
           
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           string username = txt_username.Text;
            string password = txt_password.Text;
            conn.Open();

            cmd = new SqlCommand("Select * from login WHERE username ='" + txt_username.Text + "' AND password = '"+txt_password.Text + "'", conn);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;

            if(i==1)
            {
                admin ad = new admin();
                ad.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Please check your username and password" ,"Message" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }

            conn.Close();
            cmd.Dispose();
            
        }
    }
}
