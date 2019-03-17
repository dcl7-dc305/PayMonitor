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
    public partial class frmCheckout : Form
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlCommand checkercmd;
        SqlDataAdapter adapt;
        DataTable dt;

        string connstr = ConfigurationManager.ConnectionStrings["PayMonitorDB"].ConnectionString;

        public frmCheckout(string roletype = "", string lastname = "")
        {
            InitializeComponent();
            Load_Checkout();
            Load_TotalPrice();
            btnPay.Enabled = false;
            lblLastIdSales.Visible = false;
            this.ControlBox = false;

            lblRoleType.Text = roletype;
            lblLastName.Text = lastname;
            lblRoleType.Visible = false;
            lblLastName.Visible = false;
        }

        public void Load_LastNumberInSales()
        {
            int lastId;

            SqlDataReader datareader;
            try
            {
                //conn.Open();
                checkercmd = new SqlCommand("SELECT top 1 * FROM tbl_sales order by sales_id Desc;", conn);
                datareader = checkercmd.ExecuteReader();

                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        
                        string lastIDString = datareader["sales_id"].ToString();

                        // Sales Id Generator
                        lastId = Int32.Parse(lastIDString);
                        lastId += 1;
                        lblLastIdSales.Text = lastId.ToString();
                    }
                    datareader.Close();
                }

                datareader.Close();
                //conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveCartToSales()
        {
            Random rnd = new Random();
            DateTime today = DateTime.Now;
            string todaysql = today.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string qry;
            int trans_id = rnd.Next(999999);
            int sales_id = 0;
            cmd = new SqlCommand("SELECT * FROM tbl_cart", conn);
            adapt = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapt.Fill(dt);

            try
            {
                conn.Open();
                
                foreach (DataRow dr in dt.Rows)
                {
                    Load_LastNumberInSales();
                    sales_id = Int32.Parse(lblLastIdSales.Text);
                    string sid = sales_id.ToString();
                    string tc = trans_id.ToString();
                    string td = todaysql.ToString();
                    string sl = lblLastName.Text; // put last name of operator / admin
                    string pid = dr["product_id"].ToString();
                    string pname = dr["product_name"].ToString();
                    string categ = dr["category"].ToString();
                    string qty = dr["qty"].ToString();
                    string price = dr["price"].ToString();
                    string ttlprice = dr["total_price"].ToString();

                    qry = $"INSERT INTO tbl_sales VALUES ('{sid}', '{tc}', '{td}', '{sl}', '{pid}', '{pname}', '{categ}', '{qty}', '{price}', '{ttlprice}')";
                    cmd = new SqlCommand(qry, conn);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show(qry);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                cmd.CommandText = "TRUNCATE TABLE tbl_cart";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Load_Checkout()
        {
            SqlDataReader datareader;
            DataTable dt = new DataTable();
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("SELECT * FROM tbl_cart", conn);

            try
            {
                conn.Open();
                datareader = cmd.ExecuteReader();
                if (datareader.HasRows)
                {
                    dt.Load(datareader);
                    dgCheckout.DataSource = dt;
                }
                else
                {
                    dgCheckout.DataSource = dt;
                    MessageBox.Show("[Checkout] : No Data to Show.");
                }
                datareader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Load_TotalPrice()
        {
            DataTable dt = new DataTable();
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("SELECT SUM(total_price) FROM tbl_cart", conn);

            try
            {
                conn.Open();
                // Get the sum of the table
                Object sum = cmd.ExecuteScalar();
                lblTotalPrice.Text = sum.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            SaveCartToSales();
            MessageBox.Show("Thank You! Payment Received :)");
            MessageBox.Show($"Your change is: $ {lblChange.Text}");

            this.Hide();

            frmOrdering frmOrdering = new frmOrdering(lblRoleType.Text, lblLastName.Text);
            frmOrdering.Show();
        }

        private void btnCancelCheckout_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmOrdering frm = new frmOrdering(lblRoleType.Text, lblLastName.Text);
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if( txtPayment.Text == "" )
            {
                btnPay.Enabled = false;
            }
            else if( double.Parse(txtPayment.Text) < double.Parse(lblTotalPrice.Text))
            {
                btnPay.Enabled = false;
            }
            else
            {
                double change = double.Parse(txtPayment.Text) - double.Parse(lblTotalPrice.Text);
                btnPay.Enabled = true;
                lblChange.Text = change.ToString();
            }
        }

        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Accept Numbers only
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
