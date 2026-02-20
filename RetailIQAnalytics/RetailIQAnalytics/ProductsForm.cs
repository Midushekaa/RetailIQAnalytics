using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RetailIQAnalytics.UI
{
    public partial class ProductsForm : Form
    {
        private SqlConnection conn = new SqlConnection(
            @"Server=.\SQLEXPRESS01;Initial Catalog=RetailIQAnalytics;Integrated Security=True");

        private int selectedProductId = 0;

        public ProductsForm()
        {
            InitializeComponent();
            LoadProducts();

            // Assign event handlers
            dgvProducts.CellClick += dgvProducts_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
        }

        // ================= LOAD PRODUCTS =================
        private void LoadProducts()
        {
            try
            {
                string query = @"SELECT ProductID, ProductName, CategoryID, UnitPrice, StockQuantity, ReorderLevel, CreatedAt, UpdatedAt FROM Products";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProducts.DataSource = dt;

                dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProducts.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= SELECT ROW =================
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                txtCategoryID.Text = row.Cells["CategoryID"].Value.ToString();
                txtUnitPrice.Text = row.Cells["UnitPrice"].Value.ToString();
                txtStockQuantity.Text = row.Cells["StockQuantity"].Value.ToString();
            }
        }

        // ================= ADD PRODUCT =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtCategoryID.Text) ||
                string.IsNullOrWhiteSpace(txtUnitPrice.Text) ||
                string.IsNullOrWhiteSpace(txtStockQuantity.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"INSERT INTO Products (ProductName, CategoryID, UnitPrice, StockQuantity, ReorderLevel) 
                                 VALUES (@ProductName, @CategoryID, @UnitPrice, @StockQuantity, @ReorderLevel)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@CategoryID", int.Parse(txtCategoryID.Text));
                    cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(txtUnitPrice.Text));
                    cmd.Parameters.AddWithValue("@StockQuantity", int.Parse(txtStockQuantity.Text));
                    cmd.Parameters.AddWithValue("@ReorderLevel", 10); // default

                    if (conn.State == ConnectionState.Closed) conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= UPDATE PRODUCT =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Please select a product first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE Products 
                                 SET ProductName=@ProductName,
                                     CategoryID=@CategoryID,
                                     UnitPrice=@UnitPrice,
                                     StockQuantity=@StockQuantity,
                                     UpdatedAt=GETDATE()
                                 WHERE ProductID=@ProductID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@CategoryID", int.Parse(txtCategoryID.Text));
                    cmd.Parameters.AddWithValue("@UnitPrice", decimal.Parse(txtUnitPrice.Text));
                    cmd.Parameters.AddWithValue("@StockQuantity", int.Parse(txtStockQuantity.Text));
                    cmd.Parameters.AddWithValue("@ProductID", selectedProductId);

                    if (conn.State == ConnectionState.Closed) conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= DELETE PRODUCT =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Please select a product first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Are you sure you want to delete ProductID: {selectedProductId}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Products WHERE ProductID=@ProductID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", selectedProductId);

                        if (conn.State == ConnectionState.Closed) conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ================= CLEAR FIELDS =================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtProductName.Clear();
            txtCategoryID.Clear();
            txtUnitPrice.Clear();
            txtStockQuantity.Clear();
            selectedProductId = 0;
            dgvProducts.ClearSelection();
        }

        // ================= VIEW PRODUCT =================
        private void btnView_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Please select a product first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Fetch selected product details from the DataGridView
                DataGridViewRow row = dgvProducts.SelectedRows[0];

                string details =
                    $"Product ID: {row.Cells["ProductID"].Value}\n" +
                    $"Product Name: {row.Cells["ProductName"].Value}\n" +
                    $"Category ID: {row.Cells["CategoryID"].Value}\n" +
                    $"Unit Price: {row.Cells["UnitPrice"].Value}\n" +
                    $"Stock Quantity: {row.Cells["StockQuantity"].Value}\n" +
                    $"Reorder Level: {row.Cells["ReorderLevel"].Value}\n" +
                    $"Created At: {row.Cells["CreatedAt"].Value}\n" +
                    $"Updated At: {row.Cells["UpdatedAt"].Value}";

                MessageBox.Show(details, "Product Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying product details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
