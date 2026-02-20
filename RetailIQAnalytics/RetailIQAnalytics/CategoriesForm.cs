using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RetailIQAnalytics.UI
{
    public partial class CategoriesForm : Form
    {
        // Database connection
        private SqlConnection conn = new SqlConnection(
            @"Server=.\SQLEXPRESS01;Initial Catalog=RetailIQAnalytics;Integrated Security=True");

        private int selectedCategoryId = 0;

        public CategoriesForm()
        {
            InitializeComponent();
            LoadCategories();

            // Assign event handlers
            dgvCategories.CellClick += dgvCategories_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += button1_Click;
        }

        // ================= LOAD CATEGORIES =================
        private void LoadCategories()
        {
            try
            {
                string query = "SELECT CategoryID, CategoryName, CreatedAt FROM Categories";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvCategories.DataSource = dt;

                dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCategories.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= SELECT ROW =================
        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                selectedCategoryId = Convert.ToInt32(row.Cells["CategoryID"].Value);
                txtCategoryName.Text = row.Cells["CategoryName"].Value.ToString();
            }
        }

        // ================= ADD CATEGORY =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Enter a category name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= EDIT CATEGORY =================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == 0)
            {
                MessageBox.Show("Select a category first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category name cannot be empty.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "UPDATE Categories SET CategoryName=@CategoryName WHERE CategoryID=@CategoryID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                    cmd.Parameters.AddWithValue("@CategoryID", selectedCategoryId);

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= DELETE CATEGORY =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == 0)
            {
                MessageBox.Show("Select a category first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DialogResult dr = MessageBox.Show(
                    "Are you sure you want to delete this category?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    string query = "DELETE FROM Categories WHERE CategoryID=@CategoryID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", selectedCategoryId);

                        if (conn.State == ConnectionState.Closed)
                            conn.Open();

                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= CLEAR =================
        

        private void ClearFields()
        {
            txtCategoryName.Clear();
            selectedCategoryId = 0;
            dgvCategories.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a category first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvCategories.SelectedRows[0];
            string details =
                $"Category ID: {row.Cells["CategoryID"].Value}\n" +
                $"Category Name: {row.Cells["CategoryName"].Value}\n" +
                $"Created At: {row.Cells["CreatedAt"].Value}";

            MessageBox.Show(details, "Category Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
