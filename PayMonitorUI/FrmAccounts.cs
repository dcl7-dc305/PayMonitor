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
using System.Configuration;


namespace PayMonitorUI
{
    public partial class FrmAccounts : Form
    {
        public FrmAccounts()
        {
            InitializeComponent();
            Load_ViewRegisteredData();
        }

        private SqlCommand cmd;
        private SqlConnection conn;
        private SqlCommand checkercmd;

        string connstr = ConfigurationManager.ConnectionStrings["PayMonitorDB"].ConnectionString;

        private void FrmAccounts_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
                 conn = new SqlConnection(Properties.Settings.Default.PayMonitorDB);
                 cmd = new SqlCommand("INSERT INTO tbl_accounts (account_id, role_name, username, password, firstname, lastname) VALUES (@accountID, @rolename, @username, @password, @firstname, @lastname)", conn);


                 cmd.Parameters.AddWithValue("@accountID", txtAccountID.Text);
                 cmd.Parameters.AddWithValue("@rolename", cmbAccountType.SelectedItem);
                 cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                 cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                 cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text);
                 cmd.Parameters.AddWithValue("@lastname", txtLastname.Text);

                 checkercmd = new SqlCommand("SELECT * FROM tbl_accounts WHERE username=@username", conn);
                 checkercmd.Parameters.AddWithValue("@username", txtUsername.Text);

                 try
                 {
                     SqlDataReader datareader;

                     conn.Open();
                     datareader = checkercmd.ExecuteReader();
                     if (datareader.HasRows)
                     {
                         MessageBox.Show("The " + txtUsername.Text + " username is taken.");
                         datareader.Close();
                     }
                     else
                         datareader.Close();
                         if (cmd.ExecuteNonQuery() == 1)
                         {
                             MessageBox.Show("User Successfully Added!");
                         }

                     Load_ViewRegisteredData();
                     conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        public void Load_ViewRegisteredData()
        {
            SqlDataReader datareader;
            DataTable dt = new DataTable();
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("SELECT * FROM tbl_accounts", conn);

            try
            {
                conn.Open();
                datareader = cmd.ExecuteReader();
                if (datareader.HasRows)
                {
                    dt.Load(datareader);
                    grdViewAccounts.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No Data to Show.");
                }
                datareader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Close Login Form after signing in.
            this.Hide();

            //Show Main Menu after Login Succes.
            frmMainMenu frm2 = new frmMainMenu();
            frm2.Show();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("DELETE FROM tbl_accounts WHERE username=@username", conn);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);

            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Deleted Sucessfully!");
                    Load_ViewRegisteredData();
                    txtAccountID.Text = "";
                    cmbAccountType.Text = "";
                    txtFirstname.Text = "";
                    txtLastname.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Text = "";

                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void grdViewAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Show Data from the database into the designated textboxes.
            DataGridViewRow row = grdViewAccounts.Rows[e.RowIndex];

            txtAccountID.Text = row.Cells["account_id"].Value.ToString();
            cmbAccountType.Text = row.Cells["role_name"].Value.ToString();
            txtUsername.Text = row.Cells["username"].Value.ToString();
            txtPassword.Text = row.Cells["password"].Value.ToString();
            txtFirstname.Text = row.Cells["firstname"].Value.ToString();
            txtLastname.Text = row.Cells["lastname"].Value.ToString();
            txtAccountID.Enabled = false;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear data in all textboxes
            txtAccountID.Text = "";
            cmbAccountType.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(Properties.Settings.Default.PayMonitorDB);
            cmd = new SqlCommand("UPDATE tbl_accounts SET account_id=@accountID, role_name=@rolename, username=@username, password=@password, firstname=@firstname, lastname=@lastname WHERE account_id=@accountID OR username=@username", conn);

            cmd.Parameters.AddWithValue("@accountID", txtAccountID.Text);
            cmd.Parameters.AddWithValue("@rolename", cmbAccountType.SelectedItem);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text);
            cmd.Parameters.AddWithValue("@lastname", txtLastname.Text);


            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Updated!");
                    Load_ViewRegisteredData();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}


