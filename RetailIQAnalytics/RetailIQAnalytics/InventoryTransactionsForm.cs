using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RetailIQAnalytics.UI
{
    public partial class InventoryTransactionsForm : Form
    {
        private SqlConnection conn = new SqlConnection(
            @"Server=.\SQLEXPRESS01;Initial Catalog=RetailIQAnalytics;Integrated Security=True");

        private int selectedTransactionId = 0;

        public InventoryTransactionsForm()
        {
            InitializeComponent();
            LoadTransactions();

            // Event handlers
            dgvTransactions.CellClick += dgvTransactions_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        // ================= LOAD TRANSACTIONS =================
        private void LoadTransactions()
        {
            try
            {
                string query = @"
                    SELECT T.TransactionID, P.ProductName, T.QuantityChange, T.TransactionType, T.TransactionDate
                    FROM InventoryTransactions T
                    INNER JOIN Products P ON T.ProductID = P.ProductID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTransactions.DataSource = dt;

                dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTransactions.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= SELECT ROW =================
        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTransactions.Rows[e.RowIndex];
                selectedTransactionId = Convert.ToInt32(row.Cells["TransactionID"].Value);
                txtProductID.Text = row.Cells["ProductName"].Value.ToString(); // optional: show Product ID instead of Name
                txtQuantityChange.Text = row.Cells["QuantityChange"].Value.ToString();
                txtTransactionType.Text = row.Cells["TransactionType"].Value.ToString();
            }
        }

        // ================= ADD =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text) ||
                string.IsNullOrWhiteSpace(txtQuantityChange.Text) ||
                string.IsNullOrWhiteSpace(txtTransactionType.Text))
            {
                MessageBox.Show("All fields are required.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"
                    INSERT INTO InventoryTransactions(ProductID, QuantityChange, TransactionType)
                    VALUES (@ProductID, @QuantityChange, @TransactionType)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", int.Parse(txtProductID.Text));
                    cmd.Parameters.AddWithValue("@QuantityChange", int.Parse(txtQuantityChange.Text));
                    cmd.Parameters.AddWithValue("@TransactionType", txtTransactionType.Text);

                    if (conn.State == ConnectionState.Closed) conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Transaction added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTransactions();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= EDIT =================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedTransactionId == 0)
            {
                MessageBox.Show("Select a transaction first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"
                    UPDATE InventoryTransactions
                    SET ProductID=@ProductID, QuantityChange=@QuantityChange, TransactionType=@TransactionType
                    WHERE TransactionID=@TransactionID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", int.Parse(txtProductID.Text));
                    cmd.Parameters.AddWithValue("@QuantityChange", int.Parse(txtQuantityChange.Text));
                    cmd.Parameters.AddWithValue("@TransactionType", txtTransactionType.Text);
                    cmd.Parameters.AddWithValue("@TransactionID", selectedTransactionId);

                    if (conn.State == ConnectionState.Closed) conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Transaction updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTransactions();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= DELETE =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTransactionId == 0)
            {
                MessageBox.Show("Select a transaction first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Are you sure you want to delete TransactionID: {selectedTransactionId}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM InventoryTransactions WHERE TransactionID=@TransactionID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TransactionID", selectedTransactionId);

                        if (conn.State == ConnectionState.Closed) conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("Transaction deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransactions();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // ================= CLEAR =================
        private void ClearFields()
        {
            txtProductID.Clear();
            txtQuantityChange.Clear();
            txtTransactionType.Clear();
            selectedTransactionId = 0;
            dgvTransactions.ClearSelection();
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a transaction first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvTransactions.SelectedRows[0];
            string details =
                $"Transaction ID: {row.Cells["TransactionID"].Value}\n" +
                $"Product: {row.Cells["ProductName"].Value}\n" +
                $"Quantity Change: {row.Cells["QuantityChange"].Value}\n" +
                $"Transaction Type: {row.Cells["TransactionType"].Value}\n" +
                $"Date: {row.Cells["TransactionDate"].Value}";

            MessageBox.Show(details, "Transaction Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
