using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PayMonitorUI
{
    public partial class frmLogin : Form
    {
        // Initialize DB
        SqlConnection conn;
        SqlCommand cmd;
        string ConnStr = ConfigurationManager.ConnectionStrings["PayMonitorDB"].ConnectionString;


        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter your login credentials.");
            }
            else
            {
                SqlDataReader reader; // create reader object
                conn = new SqlConnection(ConnStr); // assign the connection info
                string qry = "SELECT * FROM tbl_accounts WHERE username=@username AND password=@password"; 
                cmd = new SqlCommand(qry, conn); // Prep up Query to connection of db
                
                // Wire up from UI Form
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                try
                {
                    conn.Open(); // Open connection
                    reader = cmd.ExecuteReader(); // execute query inputs
                    if (reader.HasRows) // check if there's any data
                    {
                        MessageBox.Show("Login Success");
                    }
                    else // if there's none
                    {
                        MessageBox.Show("Login Failed");
                    }
                    reader.Close();
                    conn.Close(); // Close Connection
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }
    }
}
