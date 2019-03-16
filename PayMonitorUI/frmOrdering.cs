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
    public partial class frmOrdering : Form
    {
        SqlCommand cmd;
        SqlConnection conn;
        SqlCommand checkercmd;
        SqlDataAdapter adapt;
        DataTable dt;
        string connstr = ConfigurationManager.ConnectionStrings["PayMonitorDB"].ConnectionString;


        public frmOrdering()
        {
            InitializeComponent();
            Load_Products();
            Load_Cart();
            HideElements();

            //Disable Buttons
            btnAddToCart.Enabled = false;
            btnReturnInventory.Enabled = false;

            txtQty.MaxLength = 2;
        }

        public void HideElements()
        {
            lblCategory.Visible =false;
        }

        public void RemoveZeroProduct()
        {
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("DELETE FROM tbl_products WHERE qty=0", conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RemoveZeroCart()
        {
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("DELETE FROM tbl_cart WHERE qty=0", conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Load_TotalCharge()
        {
            SqlDataReader datareader;
            DataTable dt = new DataTable();
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("SELECT SUM(total_price) FROM tbl_cart", conn);

            try
            {
                conn.Open();
                datareader = cmd.ExecuteReader();
                if (datareader.HasRows)
                {
                    dt.Load(datareader);
                    dgInventory.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("[Products] : No Data to Show.");
                }
                datareader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Load_Products()
        {
            RemoveZeroProduct();
            SqlDataReader datareader;
            DataTable dt = new DataTable();
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("SELECT * FROM tbl_products", conn);

            try
            {
                conn.Open();
                datareader = cmd.ExecuteReader();
                if (datareader.HasRows)
                {
                    dt.Load(datareader);
                    dgInventory.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("[Products] : No Data to Show.");
                }
                datareader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Load_Cart()
        {
            RemoveZeroCart();
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
                    dgShoppingCart.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("[Cart] : No Data to Show.");
                }
                datareader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddToCart.Enabled = true; // Disable Add to Cart
            btnReturnInventory.Enabled = false; // Enable Return to Inventory

            DataGridViewRow row;
            if (e.RowIndex < 0) // Resolving Index out of range
            {
                row = dgInventory.Rows[0]; // force select first row in db
            }
            else
            {
                row = dgInventory.Rows[e.RowIndex];
            }

            double qtyDefault = 1;
            double totalPrice;

            if (lblUnitPrice.Text == "") // if selected no Unit Price don't return 0
            {
                totalPrice = double.Parse(txtQty.Text) * 0;
            }
            else
            {
                totalPrice = (double)qtyDefault * double.Parse(lblUnitPrice.Text);
            }

            lblProdIdVal.Text = row.Cells["product_id"].Value.ToString();
            lblProdNameVal.Text = row.Cells["product_name"].Value.ToString();
            txtQty.Text = qtyDefault.ToString();
            lblUnitPrice.Text = row.Cells["price"].Value.ToString();
            lblTotalPrice.Text = totalPrice.ToString();
            lblCategory.Text = row.Cells["category"].Value.ToString();

            QtyReset();
        }

        

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            QtyReset(); // if total value has no price yet, set the value of quantity to 1
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Accept Numbers only
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public void QtyReset()
        {
            if (txtQty.Text == "") // if total value has no price yet, set the value of quantity to 1
            {
                double totalPrice = 1 * double.Parse(lblUnitPrice.Text);
                lblTotalPrice.Text = totalPrice.ToString();
            }
            else
            {
                if(lblUnitPrice.Text == "") // if selected no Unit Price don't return 0
                {
                    double totalPrice = double.Parse(txtQty.Text) * 0;
                    lblTotalPrice.Text = totalPrice.ToString();
                }
                else
                {
                    double totalPrice = double.Parse(txtQty.Text) * double.Parse(lblUnitPrice.Text);
                    lblTotalPrice.Text = totalPrice.ToString();
                }

            }
        }

        private void frmOrdering_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstr);
            

            checkercmd = new SqlCommand("SELECT * FROM tbl_cart WHERE product_id=@product_id", conn);
            checkercmd.Parameters.AddWithValue("@product_id", lblProdIdVal.Text);

            try
            {
                SqlDataReader datareader;

                conn.Open();
                datareader = checkercmd.ExecuteReader();

                if (datareader.HasRows) // if there's existing in cart,
                {
                    datareader.Close();
                    MessageBox.Show("Updated Successfully and added to cart!");

                    // Update Cart only -> Decrement value from Cart
                    cmd = new SqlCommand("UPDATE tbl_cart SET qty = qty + @qty WHERE product_id = @product_id", conn);
                    cmd.Parameters.AddWithValue("@product_id", lblProdIdVal.Text);
                    cmd.Parameters.AddWithValue("@qty", txtQty.Text);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    datareader.Close();

                    MessageBox.Show("Successfully added to cart!");

                    // Add New Item to Cart
                    cmd = new SqlCommand("INSERT INTO tbl_cart (product_id, product_name, category, qty, price, staff_name, total_price) VALUES (@product_id, @product_name, @category, @qty, @price, @staff_name, @total_price)", conn);
                    cmd.Parameters.AddWithValue("@product_id", lblProdIdVal.Text);
                    cmd.Parameters.AddWithValue("@product_name", lblProdName.Text);
                    cmd.Parameters.AddWithValue("@category", lblCategory.Text);
                    cmd.Parameters.AddWithValue("@price", lblUnitPrice.Text);
                    cmd.Parameters.AddWithValue("@qty", txtQty.Text);
                    cmd.Parameters.AddWithValue("@total_price", lblTotalPrice.Text);
                    cmd.ExecuteNonQuery();
                }

                // Update Inventory -> Decrement value from Inventory
                cmd = new SqlCommand("UPDATE tbl_products SET qty = qty - @qty WHERE product_id = @product_id", conn);
                cmd.Parameters.AddWithValue("@product_id", lblProdIdVal.Text);
                cmd.Parameters.AddWithValue("@qty", txtQty.Text);
                cmd.ExecuteNonQuery();

                Load_Products();
                Load_Cart();

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btnReturnInventory_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstr);
            checkercmd = new SqlCommand("SELECT * FROM tbl_products WHERE product_id=@product_id", conn);
            checkercmd.Parameters.AddWithValue("@product_id", lblProdIdVal.Text);

            try
            {
                SqlDataReader datareader;
                
                conn.Open();

                datareader = checkercmd.ExecuteReader();

                if (datareader.HasRows) // check if duplicate in inventory
                {
                    datareader.Close();

                    MessageBox.Show("Updated and Returned Back the Product Successfully!");

                    // Update Current Record on DB
                    cmd = new SqlCommand("UPDATE tbl_products SET qty = qty + @qty WHERE product_id = @product_id", conn);
                    cmd.Parameters.AddWithValue("@product_id", lblProdIdVal.Text);
                    cmd.Parameters.AddWithValue("@qty", txtQty.Text);
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    datareader.Close();

                    MessageBox.Show("Returned Back the Item Successfully!");

                    // if there are no records, insert new data to db.
                    cmd = new SqlCommand("INSERT INTO tbl_products (product_id, product_name, category, qty, price) VALUES (@product_id, @product_name, @category, @qty, @price)", conn);
                    cmd.Parameters.AddWithValue("@product_id", lblProdIdVal.Text);
                    cmd.Parameters.AddWithValue("@product_name", lblProdName.Text);
                    cmd.Parameters.AddWithValue("@category", lblCategory.Text);
                    cmd.Parameters.AddWithValue("@price", lblUnitPrice.Text);
                    cmd.Parameters.AddWithValue("@qty", txtQty.Text);
                    cmd.ExecuteNonQuery();
                }

                // Update Cart -> Decrement value from Cart
                cmd.CommandText = "UPDATE tbl_cart SET qty = qty - @qty2 WHERE product_id = @product_id2";
                cmd.Parameters.AddWithValue("@product_id2", lblProdIdVal.Text);
                cmd.Parameters.AddWithValue("@qty2", txtQty.Text);
                cmd.ExecuteNonQuery();

                Load_Products();
                Load_Cart();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgShoppingCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAddToCart.Enabled = false; // Disable Add to Cart
            btnReturnInventory.Enabled = true; // Enable Return to Inventory

            DataGridViewRow row;

            if (e.RowIndex < 0) // Resolving Index out of range
            {
                row = dgShoppingCart.Rows[0]; // force select first row in db
            }
            else
            {
                row = dgShoppingCart.Rows[e.RowIndex];
            }

            double qtyDefault = 1;
            double totalPrice;

            if (lblUnitPrice.Text == "") // if selected no Unit Price don't return 0
            {
                totalPrice = double.Parse(txtQty.Text) * 0;
            }
            else
            {
                totalPrice = (double)qtyDefault * double.Parse(lblUnitPrice.Text);
            }

            lblProdIdVal.Text = row.Cells["product_id"].Value.ToString();
            lblProdNameVal.Text = row.Cells["product_name"].Value.ToString();
            txtQty.Text = qtyDefault.ToString();
            lblUnitPrice.Text = row.Cells["price"].Value.ToString();
            lblTotalPrice.Text = totalPrice.ToString();
            lblCategory.Text = row.Cells["category"].Value.ToString();

            QtyReset();
        }
    }
}
