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
    public partial class frmSalesReport : Form
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlCommand checkercmd;
        SqlDataAdapter adapt;
        DataTable dt;

        // Initialize All Header Names
        string sid = "Sales ID";
        string tc = "Transaction Code";
        string td = "Transaction Date";
        string slname = "Staff L. Name";
        string prodid = "Product ID";
        string pname = "Product Name";
        string qty = "Quantity Sold";
        string price = "Unit Price";
        string ttlprice = "Total Price";

        string connstr = ConfigurationManager.ConnectionStrings["PayMonitorDB"].ConnectionString;

        public frmSalesReport(string roletype = "", string lastname = "")
        {
            InitializeComponent();
            Load_SalesReport();

            lblRoleType.Text = roletype;
            lblLastName.Text = lastname;
            lblRoleType.Visible = false;
            lblLastName.Visible = false;
        }

        public void Load_SalesReport()
        {
            Load_TotalSales(); // Loads Total Sales for every

            SqlDataReader datareader;
            DateTime today = DateTime.Today;
            string todaysql = today.ToString("yyyy-MM-dd");
            DataTable dt = new DataTable();
            conn = new SqlConnection(connstr);

            // Rename all Headers and search all transaction within 24 hours.
            cmd = new SqlCommand($"SELECT sales_id AS '{sid}', transaction_code  AS '{tc}', transaction_date  AS '{td}', staff_lname  AS '{slname}', product_id  AS '{prodid}', product_name  AS '{pname}', qty AS '{qty}', price AS '{price}', total_price AS '{ttlprice}' FROM tbl_sales WHERE transaction_date >= DATEADD(hh, -24, GETDATE()) ORDER BY transaction_date DESC, sales_id DESC", conn);

            try
            {
                conn.Open();
                datareader = cmd.ExecuteReader();
                if (datareader.HasRows)
                {
                    dt.Load(datareader);
                    dgSales.DataSource = dt;
                }
                else
                {
                    dgSales.DataSource = dt; // refresh data grid even its empty
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

        public void Load_TotalSales()
        {
            DataTable dt = new DataTable();
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("SELECT SUM(total_price) FROM tbl_sales", conn);

            try
            {
                conn.Open();
                // Get the sum of the table
                Object sum = cmd.ExecuteScalar();
                lblTotalSales.Text = sum.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstr);
            string startDate = dtStart.Value.ToString("yyyy-MM-dd");
            string endDate = dtEnd.Value.ToString("yyyy-MM-dd");
            string sid = txtSalesId.Text;
            string tc = txtTransactionCode.Text;
            string sln = txtStaffLastName.Text;
            string pid = txtProdId.Text;
            string pname = txtProdName.Text;

            // search anything by account_id, username, firstname, last_name, role_name
            string qry = $"SELECT *, SUM(total_price) OVER () AS SumTotal FROM tbl_sales WHERE transaction_date BETWEEN '{startDate}' AND '{endDate}' OR sales_id LIKE '%{sid}%' AND transaction_code LIKE '%{tc}%' AND staff_lname LIKE '%{sln}%' AND product_id LIKE '%{pid}%' ORDER BY sales_id DESC, transaction_date DESC;";
            adapt = new SqlDataAdapter(qry, conn);

            conn.Open();
            dt = new DataTable();
            adapt.Fill(dt);
            dt.Columns["sales_id"].ColumnName = "Sales ID";
            dt.Columns["transaction_code"].ColumnName = "Transaction Code";
            dt.Columns["transaction_date"].ColumnName = "Transaction Date";
            dt.Columns["staff_lname"].ColumnName = "Staff L. Name";
            dt.Columns["product_id"].ColumnName = "Product ID";
            dt.Columns["product_name"].ColumnName = "Product Name";
            dt.Columns["qty"].ColumnName = "Quantity";
            dt.Columns["price"].ColumnName = "Price";
            dt.Columns["total_price"].ColumnName = "Total Price";

            Object field = dt.Rows[dt.Rows.Count - 1]["SumTotal"]; // Get Total of SumTotal
            lblTotalSales.Text = field.ToString();

            dt.Columns.RemoveAt(dt.Columns.Count - 1); // Hide Last Column after getting SumTotal

            dgSales.DataSource = dt;
            conn.Close();
        }

        private void btnBackMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu(lblRoleType.Text, lblLastName.Text);
            frm.Show();
        }
    }
}
