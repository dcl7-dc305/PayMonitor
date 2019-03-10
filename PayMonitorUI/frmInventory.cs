﻿using System;
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
        bool isEdit = false;
        Dictionary<string, string> messages = new Dictionary<string, string>()
        {
            {"form invalid", "Form is incomplete"},
            {"add success", "Inventory added"},
            {"add duplicate", "Inventory duplicate"},
            {"update success", "Inventory updated"},
        };
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
                string.IsNullOrEmpty(this.cmbCategory.SelectedItem.ToString()) ||
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
            this.searchCategory.Text = "";
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
            MessageBox.Show(searchCategory);
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
            this.submitButton.Text = isEdit ? "Update" : "Add";
        }

        private int getCategoryIndex(string category)
        {
            return Array.IndexOf(this.categories, category);
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
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
    }
}