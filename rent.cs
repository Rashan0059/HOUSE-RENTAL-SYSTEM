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
    public partial class rent : Form
    {
        public rent()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RPMF38K;Initial Catalog=eapartment;Integrated Security=True");
        SqlCommand cmd;
        private void GetShowDetail()
        {

            SqlCommand cmd = new SqlCommand("select * from rent", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridViewrent.DataSource = dt;

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
            dateTimePickerR.ResetText();
            dateTimePickerE.ResetText();
            txt_Ano.Clear();
            comboBoxtype.Text = "";
            txt_rate.Clear();
        }

        private void rent_Load(object sender, EventArgs e)
        {
            GetShowDetail();
        }
      

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("INSERT INTO rent values('" + txt_id.Text + "','" + txt_name.Text + "','" + dateTimePickerR.Value + "','" + dateTimePickerE.Value + "','" + txt_Ano.Text + "','" + comboBoxtype.SelectedItem+ "','" + txt_rate.Text + "')", con);
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("Delete from rent where id= '" + txt_id.Text + "'", con);
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
      

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("Update rent set name='" + txt_name.Text + "',rdate='" + dateTimePickerR.Value + "',edate='" + dateTimePickerE.Value + "',Ano='"+txt_Ano.Text+"', type = '"+comboBoxtype.SelectedItem+"', rate = '"+ txt_rate.Text+ "' where id= '" + txt_id.Text + "'", con);
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
    }
}
