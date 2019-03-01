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
    // TODO 
    // make quantity and price accept only number

    public partial class frmInventory : Form
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PayMonitorDB"].ConnectionString);
        string[] categories = { 
            "Category 1",
            "Category 2",
            "Category 3"
        };


        public frmInventory()
        {
            InitializeComponent();

            // initialize items for category comboboxes
            foreach (string category in this.categories)
            {
                this.cmbCategory.Items.Add(category);
                this.searchCategory.Items.Add(category);
            }
            this.cmbCategory.SelectedIndex = 0;
            this.searchCategory.SelectedIndex = 0;
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            this.refreshTable();
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (!this.isFormValid())
            {
                MessageBox.Show("Form invalid"); // TODO: refactor message strings
                return;
            }
            
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO tbl_products (product_id, product_name, category, price, qty) VALUES (@product_id, @product_name, @category, @price, @qty)", this.sqlConnection);

            sqlCommand.Parameters.AddWithValue("@product_id", this.txtProductID.Text);
            sqlCommand.Parameters.AddWithValue("@product_name", this.txtProductName.Text);
            sqlCommand.Parameters.AddWithValue("@category", this.cmbCategory.SelectedItem.ToString());
            sqlCommand.Parameters.AddWithValue("@price", this.txtPrice.Text);
            sqlCommand.Parameters.AddWithValue("@qty", this.txtQuantity.Text);

            sqlConnection.Open();
            try
            {
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("1:1 succ"); // TODO: refactor message strings
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            sqlConnection.Close();
            this.refreshTable();

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }


        #region helpers
        private bool isFormValid()
        {
            return !(
                string.IsNullOrEmpty(this.txtProductID.Text) ||
                string.IsNullOrEmpty(this.txtProductName.Text) ||
                string.IsNullOrEmpty(this.cmbCategory.SelectedItem.ToString()) ||
                string.IsNullOrEmpty(this.txtPrice.Text) ||
                string.IsNullOrEmpty(this.txtQuantity.Text)
            );
        }

        private void clearForm()
        {
            this.txtProductID.Text = "";
            this.txtProductName.Text = "";
            this.cmbCategory.SelectedIndex = 0;
            this.txtPrice.Text = "";
            this.txtQuantity.Text = "";
        }

        private void refreshTable()
        {
            SqlDataReader datareader;
            DataTable dt = new DataTable();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM tbl_products", this.sqlConnection);

            this.sqlConnection.Open();
            try
            {
                datareader = sqlCommand.ExecuteReader();
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
                this.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.sqlConnection.Close();
        }
        #endregion
    }
}
