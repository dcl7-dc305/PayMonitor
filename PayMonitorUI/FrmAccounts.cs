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
        public FrmAccounts(string roletype = "", string lastname = "")
        {
            InitializeComponent();
            Load_ViewRegisteredData();

            lblRoleType.Text = roletype;
            lblLast.Text = lastname;
            lblRoleType.Visible = false;
            lblLast.Visible = false;

            btnUpdate.Enabled = false;
        }

        SqlCommand cmd;
        SqlConnection conn;
        SqlCommand checkercmd;
        SqlDataAdapter adapt;
        DataTable dt;


        string connstr = ConfigurationManager.ConnectionStrings["PayMonitorDB"].ConnectionString;

        private void FrmAccounts_Load(object sender, EventArgs e)
        {
            //conn = new SqlConnection(connstr);
            //conn.Open();
            //adapt = new SqlDataAdapter("select * from tbl_accounts", conn);
            //dt = new DataTable();
            //adapt.Fill(dt);
            //grdViewAccounts.DataSource = dt;
            //conn.Close();
            Load_ViewRegisteredData();
            AutoIncrementIDForm();



        }

        public void AutoIncrementIDForm()
        {
            // Force Auto Increment Value
            SqlDataReader datareader;
            try
            {
                conn.Open();
                checkercmd = new SqlCommand("SELECT top 1 * FROM tbl_accounts order by account_id Desc;", conn);
                datareader = checkercmd.ExecuteReader();

                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        string lastIDString = datareader["account_id"].ToString();
                        int lastId = Int32.Parse(lastIDString);
                        lastId += 1;
                        txtAccountID.Text = lastId.ToString();
                        txtAccountID.Enabled = false;
                    }
                    datareader.Close();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstr);
            //cmd.CommandText = "SET IDENTITY_INSERT tbl_accounts ON";
            cmd = new SqlCommand("INSERT INTO tbl_accounts (account_id, role_name, username, password, firstname, lastname) VALUES (@accountID, @rolename, @username, @password, @firstname, @lastname)", conn);

            cmd.Parameters.AddWithValue("@accountID", txtAccountID.Text);
            cmd.Parameters.AddWithValue("@rolename", cmbAccountType.SelectedItem);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text);
            cmd.Parameters.AddWithValue("@lastname", txtLastname.Text);

            checkercmd = new SqlCommand("SELECT * FROM tbl_accounts WHERE account_id=@accountID OR username=@username", conn);
            checkercmd.Parameters.AddWithValue("@accountID", txtAccountID.Text);
            checkercmd.Parameters.AddWithValue("@username", txtUsername.Text);

            try
            {
                SqlDataReader datareader;

                conn.Open();
                datareader = checkercmd.ExecuteReader();

                if (datareader.HasRows)
                {
                    MessageBox.Show("The " + txtUsername.Text + " username is taken. It has user id =" + txtAccountID.Text + ".");
                    datareader.Close();
                }
                else
                {
                    datareader.Close();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("User Successfully Added!");
                    }
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
            frmMainMenu frm2 = new frmMainMenu(lblRoleType.Text, lblLast.Text);
            frm2.Show();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("DELETE FROM tbl_accounts WHERE account_id=@account_id OR username=@username", conn);
            cmd.Parameters.AddWithValue("@account_id", txtAccountID.Text);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);

            try
            {
                conn.Open();
                if (txtAccountID.Text == "1" || txtAccountID.Text == "0")
                {
                    // Don't Allow to delete super administrator.
                    MessageBox.Show("You don't have a permission to delete this administrator");
                }
                else
                {
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

            // Force Auto Increment Value
            AutoIncrementIDForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAccountID.Text == "" || cmbAccountType.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtFirstname.Text == "" || txtLastname.Text == "")
            {
                MessageBox.Show("Form Incomplete. Please fill up form.");
                btnUpdate.Enabled = false;
            }
            else
            {
                conn = new SqlConnection(connstr);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            {
                conn = new SqlConnection(connstr);
                conn.Open();
                // search anything by account_id, username, firstname, last_name, role_name
                string qry = $"SELECT * FROM tbl_accounts WHERE account_id LIKE '%{txtSearch.Text}%' OR username LIKE '%{txtSearch.Text}%' OR firstname LIKE '%{txtSearch.Text}%' OR lastname LIKE '%{txtSearch.Text}%' OR role_name LIKE '%{txtSearch.Text}%'";
                adapt = new SqlDataAdapter(qry, conn);
                dt = new DataTable();
                adapt.Fill(dt);
                grdViewAccounts.DataSource = dt;
                conn.Close();
            }
        }

        private void lblSearch_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtAccountID_Validating(object sender, CancelEventArgs e)
        {
 
        }

        private void cmbAccountType_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAccountType.Text))
            {
                e.Cancel = true;
                cmbAccountType.Focus();
                errorProvider.SetError(cmbAccountType, "Please choose the account type!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbAccountType, "");
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                e.Cancel = true;
                cmbAccountType.Focus();
                errorProvider.SetError(txtUsername, "Please enter your Username!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                cmbAccountType.Focus();
                errorProvider.SetError(txtPassword, "Please enter your Password!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtPassword, "");
            }
        }

        private void txtFirstname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstname.Text))
            {
                e.Cancel = true;
                cmbAccountType.Focus();
                errorProvider.SetError(txtFirstname, "Please enter your Firstname!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtFirstname, "");
            }
        }

        private void txtLastname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastname.Text))
            {
                e.Cancel = true;
                cmbAccountType.Focus();
                errorProvider.SetError(txtLastname, "Please enter your Lastname!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtLastname, "");
            }
        }

        private void grdViewAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;

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

        private void lblManageAccount_Click(object sender, EventArgs e)
        {

        }
    }
}

