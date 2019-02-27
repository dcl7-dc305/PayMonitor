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
        public frmMainMenu()
        {
            InitializeComponent();
        }


        private void btnAccount_Click(object sender, EventArgs e)
        {
            //Close Login Form after signing in.
            this.Hide();

            //Show Main Menu after Login Succes.
            FrmAccounts frm3 = new FrmAccounts();
            frm3.Show();

        }
    }
}
