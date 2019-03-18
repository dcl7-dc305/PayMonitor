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
    // [done] make id, quantity and price accept only number
    // form validation style - error provider
    // default form category to "other"
    // default search category to "all"
    // implement isDuplicate

    public partial class frmInventory : Form
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PayMonitorDB"].ConnectionString);
        bool isEdit = false;
        Dictionary<string, string> messages = new Dictionary<string, string>()
        {
            {"form invalid", "Form is incomplete"},
            {"add success", "Inventory added"},
            {"add duplicate", "Inventory duplicate"},
            {"update success", "Inventory updated"},
        };
        string[] categories = { 
            "Frozen Food",
            "Meat",
            "Dairy",
            "Rice",
            "Cleaners",
            "Paper Goods",
            "Personal Care",
            "Other"
        };


        public frmInventory(string roletype = "", string lastname = "")
        {
            InitializeComponent();
            
            lblRoleType.Text = roletype;
            lblLastName.Text = lastname;
            lblRoleType.Visible = false;
            lblLastName.Visible = false;

            // initialize items for category comboboxes
            foreach (string category in this.categories)
            {
                this.cmbCategory.Items.Add(category);
                this.searchCategory.Items.Add(category);
            }
            this.cmbCategory.SelectedIndex = -1;
            this.searchCategory.SelectedIndex = -1;
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            this.reloadTable();
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!this.isFormValid())
            {
                MessageBox.Show(this.messages["form invalid"]);
                return;
            }

            if (!this.isEdit)
            {
                if (this.isDuplicate(Convert.ToInt32(this.txtProductID.Text)))
                {
                    MessageBox.Show(this.messages["add duplicate"]);
                    return;
                }
            }

            SqlCommand sqlCommand = new SqlCommand(!this.isEdit
                ? "INSERT INTO tbl_products (product_id, product_name, category, price, qty) VALUES (@product_id, @product_name, @category, @price, @qty)"
                : "UPDATE tbl_products SET product_id=@product_id, product_name=@product_name, category=@category, price=@price, qty=@qty WHERE product_id=@product_id"
            , this.sqlConnection);

            sqlCommand.Parameters.AddWithValue("@product_id", this.txtProductID.Text);
            sqlCommand.Parameters.AddWithValue("@product_name", this.txtProductName.Text);
            sqlCommand.Parameters.AddWithValue("@category", this.cmbCategory.SelectedItem.ToString());
            sqlCommand.Parameters.AddWithValue("@price", this.txtPrice.Text);
            sqlCommand.Parameters.AddWithValue("@qty", this.txtQuantity.Text);

            this.sqlConnection.Open();
            try
            {
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show(!this.isEdit
                    ? this.messages["add success"]
                    : this.messages["update success"]);
                this.clearForm();
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            this.sqlConnection.Close();
            this.reloadTable();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void grdViewAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow inventoryItem = gridViewInventory.Rows[e.RowIndex];
            this.setEdit(true);
            this.setFormValue(
                inventoryItem.Cells["product_id"].Value.ToString(),
                inventoryItem.Cells["product_name"].Value.ToString(),
                inventoryItem.Cells["category"].Value.ToString(),
                inventoryItem.Cells["price"].Value.ToString(),
                inventoryItem.Cells["qty"].Value.ToString()
            );
        }

        #region helpers
        private bool isDuplicate(int id)
        {
            // TODO
            return false;
        }
        private bool isFormValid()
        {
            return !(
                string.IsNullOrEmpty(this.txtProductID.Text) ||
                string.IsNullOrEmpty(this.txtProductName.Text) ||
                this.cmbCategory.SelectedIndex < 0 ||
                string.IsNullOrEmpty(this.txtPrice.Text) ||
                string.IsNullOrEmpty(this.txtQuantity.Text)
            );
        }

        private void clearForm()
        {
            this.setFormValue();
            this.setEdit(false);
        }

        private void clearSearch()
        {
            this.searchTerm.Text = "";
            this.searchCategory.SelectedIndex = -1;
        }

        private string getComboBoxSelecteditem(ComboBox comboBox)
        {
            Object selectedItem = comboBox.SelectedItem;
            return selectedItem != null ? selectedItem.ToString() : null; 
        }

        private void reloadTable()
        {
            SqlDataReader datareader;
            DataTable datatable = new DataTable();
            string searchTerm = this.searchTerm.Text;
            string searchCategory = this.getComboBoxSelecteditem(this.searchCategory);
            string qry = $"SELECT * FROM tbl_products WHERE " +
                $"(product_id LIKE '%{searchTerm}%' OR " +
                $"product_name LIKE '%{searchTerm}%' OR " +
                $"category LIKE '%{searchTerm}%' OR " +
                $"price LIKE '%{searchTerm}%' OR " +
                $"qty LIKE '%{searchTerm}%')";

            if (!String.IsNullOrEmpty(searchCategory))
            {
                qry = qry + $" AND (category = '{searchCategory}')";
            }

            SqlCommand sqlCommand = new SqlCommand(qry, this.sqlConnection);

            this.sqlConnection.Open();
            try
            {
                datareader = sqlCommand.ExecuteReader();
                if (datareader.HasRows)
                {
                    datatable.Load(datareader);
                    gridViewInventory.DataSource = datatable;
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

        private void setFormValue(string id = "", string productName = "", string category = "", string price = "", string quantity = "")
        {
            this.txtProductID.Text = id;
            this.txtProductName.Text = productName;
            this.cmbCategory.SelectedIndex = this.getCategoryIndex(category);
            this.txtPrice.Text = price;
            this.txtQuantity.Text = quantity;
        }

        private void setEdit(bool isEdit)
        {
            this.isEdit = isEdit;
            this.txtProductID.Enabled = !isEdit;
            this.submitButton.Text = (isEdit ? "Update" : "Add") + "Product";
        }

        private int getCategoryIndex(string category)
        {
            return Array.IndexOf(this.categories, category);
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblRoleType.Text == "Admin")
            {
                VerifyDelete();
            }
            else
            {
                // Admin Permission Here.
                frmAdminPermission frmAdminPermission = new frmAdminPermission();
                //frmAdminPermission.Show();

                if (frmAdminPermission.ShowDialog(this) == DialogResult.OK)
                {
                    VerifyDelete();
                }
                else
                    // Do nothing

                frmAdminPermission.Dispose();
            }
            
        }

        public void VerifyDelete()
        {
            DialogResult verify = MessageBox.Show("Are you sure to delete this product?", "Confirmation", MessageBoxButtons.YesNo);
            if (verify == DialogResult.Yes)
            {
                DeleteProduct();
            }
        }

        public void DeleteProduct()
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM tbl_products WHERE product_id=@product_id", this.sqlConnection);
            sqlCommand.Parameters.AddWithValue("@product_id", this.txtProductID.Text);

            try
            {
                this.sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Data Deleted Sucessfully!");
                this.clearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.sqlConnection.Close();
            this.reloadTable();
        }

        private void searchTerm_TextChanged(object sender, EventArgs e)
        {
            this.reloadTable();
        }

        private void searchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.reloadTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.clearSearch();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Hide this
            this.Hide();

            // Show Main Menu
            frmMainMenu frmMainMenu = new frmMainMenu(lblRoleType.Text, lblLastName.Text);
            frmMainMenu.Show();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
