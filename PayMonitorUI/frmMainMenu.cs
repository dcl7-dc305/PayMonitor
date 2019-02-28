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
        public frmMainMenu(string roletype = "") // Set default type string to become optional value
        {
            InitializeComponent();

            lblRole.Text = roletype; // initialize role
        }


        private void btnAccount_Click(object sender, EventArgs e)
        {
            //Close Login Form after signing in.
            this.Hide();

            //Show Main Menu after Login Success.
            FrmAccounts frm3 = new FrmAccounts(lblRole.Text);
            frm3.Show();

        }
    }
}
