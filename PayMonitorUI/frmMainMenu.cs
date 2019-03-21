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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu(string roletype = "", string lastname = "")
        { 
            InitializeComponent();

            lblRoleType.Text = roletype;
            lblLastName.Text = lastname;

            if(lblRoleType.Text == "Staff") // Staff Permissions
            {
                btnAccount.Enabled = false;
            }
        }


        private void btnAccount_Click(object sender, EventArgs e)
        {
            //Hide MainMenu.
            this.Hide();

            //Show Accounts.
            FrmAccounts FrmAccounts = new FrmAccounts(lblRoleType.Text, lblLastName.Text);
            FrmAccounts.Show();

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            //Hide MainMenu.
            this.Hide();

            //Show Inventory.
            frmInventory frmInventory = new frmInventory(lblRoleType.Text, lblLastName.Text);
            frmInventory.Show();
        }

        private void btnOrdering_Click(object sender, EventArgs e)
        {
            //Hide MainMenu.
            this.Hide();

            //Show Ordering.
            frmOrdering frmOrdering = new frmOrdering(lblRoleType.Text, lblLastName.Text);
            frmOrdering.Show();
        }

        private void btnSalesreport_Click(object sender, EventArgs e)
        {
            //Hide MainMenu.
            this.Hide();

            //Show Ordering.
            frmSalesReport frmSalesReport = new frmSalesReport(lblRoleType.Text, lblLastName.Text);
            frmSalesReport.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Hide Main Menu
            this.Hide();

            // Back to Logout
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void lblLastName_Click(object sender, EventArgs e)
        {

        }

        private void lblRoleType_Click(object sender, EventArgs e)
        {

        }
    }
}
