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
    public partial class tents : Form
    {
        public tents()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RPMF38K;Initial Catalog=eapartment;Integrated Security=True");
        SqlCommand cmd;
       
        private void label7_Click(object sender, EventArgs e)
        {
            admin ad = new admin();
            ad.Show();
            this.Hide();
        }
        private void GetShowDetail()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-RPMF38K;Initial Catalog=eapartment;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from tenant", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridViewtenant.DataSource = dt;
            
        }

        private void tents_Load(object sender, EventArgs e)
        {
            GetShowDetail();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_nic.Clear();
            txt_add.Clear();
            txt_tel.Clear();
            txt_dep.Clear();
            txt_rel.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("INSERT INTO tenant values('" +txt_id.Text + "','" + txt_name.Text + "','" + txt_nic.Text + "','" + txt_add.Text + "','" + txt_tel.Text + "','" + txt_dep.Text + "','" + txt_rel.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                    MessageBox.Show("successfully saved");
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GetShowDetail();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {


            try
            {
                con.Open();

                cmd = new SqlCommand("Update tenant set name='" + txt_name.Text + "', nic='" + txt_nic.Text + "', address ='" + txt_add.Text + "', tel='" + txt_tel.Text + "', depen='" + txt_dep.Text + "', rel='" + txt_rel.Text + "' where id = '" + txt_id.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    MessageBox.Show("successfully updated");
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GetShowDetail();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("Delete from tenant where id= '" + txt_id.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    MessageBox.Show("successfully delete");
                con.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Please check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GetShowDetail();
        }
    }
    
}

