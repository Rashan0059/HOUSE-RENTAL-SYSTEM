using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_Project
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            tents ten = new tents();
            ten.Show();
            this.Hide();
        }

        private void appartment_Click(object sender, EventArgs e)
        {
            apartment apart = new apartment();
            apart.Show();
            this.Hide();
        }

        private void landload_Click(object sender, EventArgs e)
        {
            landloard land = new landloard();
            land.Show();
            this.Hide();

        }

        private void rents_Click(object sender, EventArgs e)
        {
            rent re = new rent();
            re.Show();
            this.Hide();
        }

        private void reports_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            paymentcs pay = new paymentcs();
                pay.Show();
            this.Hide();
        }
    }
}
