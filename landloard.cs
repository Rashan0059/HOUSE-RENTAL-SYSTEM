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
    public partial class landloard : Form
    {
        public landloard()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RPMF38K;Initial Catalog=eapartment;Integrated Security=True");
        SqlCommand cmd;

        private void GetShowDetail()
        {

            SqlCommand cmd = new SqlCommand("select * from landloard", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridViewland.DataSource = dt;

        }
        private void label7_Click(object sender, EventArgs e)
        {
            admin ad = new admin();
            ad.Show();
            this.Hide();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            txt_id.Clear();
            txt_name.Clear();
            txt_address.Clear();
            txt_tel.Clear();
            txt_cate.Text = "";
            txt_des.Clear();
            txt_price.Clear();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("INSERT INTO landloard values('" + txt_id.Text + "','" + txt_name.Text + "','" + txt_address.Text + "','" + txt_tel.Text + "','" + comboBox.SelectedItem + "','" + txt_des.Text + "','" + txt_price.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
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

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("Update landloard set name='"+txt_name.Text+ "' , address='" + txt_address.Text + "' ,tel='" + txt_tel.Text + "' ,catergory='" + comboBox.SelectedItem + "', description='" + txt_des.Text + "', price='" + txt_price.Text + "' where id= '" + txt_id.Text + "'", con);
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

                cmd = new SqlCommand("Delete from landloard where id= '" + txt_id.Text + "'", con);
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

        private void landloard_Load(object sender, EventArgs e)
        {
            GetShowDetail();
        }
    }
}
