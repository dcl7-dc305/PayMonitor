using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayMonitorUI
{
    public partial class frmChooseRole : Form
    {
        public frmChooseRole()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmOrdering frmOrdering = new frmOrdering();
            frmOrdering.Show();
        }
    }
}
