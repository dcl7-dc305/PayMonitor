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
                MessageBox.Show("Please fill up the form:");
            }
            else
            {
                SqlDataReader reader; // create reader object
                conn = new SqlConnection(ConnStr); // assign the connection info
                cmd = new SqlCommand("SELECT * FROM tbl_accounts WHERE username=@username AND password=@password", conn);

                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                try
                {
                    conn.Open(); // open connection
                    reader = cmd.ExecuteReader(); // execute command and assign the result into
                    if (reader.HasRows) // check if there is any record in reader
                    {
                        MessageBox.Show("Login Success");
                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
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
}
