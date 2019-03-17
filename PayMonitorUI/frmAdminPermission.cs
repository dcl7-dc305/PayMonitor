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
    public partial class frmAdminPermission : Form
    {
        public frmAdminPermission(string roletype = "", string lastname = "", string prodId = "")
        {
            InitializeComponent();

            lblProdId.Text = prodId;
            lblRoleType.Text = roletype;
            lblLastName.Text = lastname;
            lblProdId.Visible = false;
            lblRoleType.Visible = false;
            lblLastName.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPinCode.Text == "1234")
            {
                MessageBox.Show("Success - Entered PIN Code");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Failed - Entered PIN Code");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
