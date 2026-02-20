using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RetailIQAnalytics.UI
{
    public partial class UsersForm : Form
    {
        // 🔹 Single SqlConnection object
        private SqlConnection conn = new SqlConnection(
            @"Server=.\SQLEXPRESS01;Initial Catalog=RetailIQAnalytics;Integrated Security=True");

        private int selectedUserId = 0;

        public UsersForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        // ================= LOAD USERS =================
        private void LoadUsers()
        {
            try
            {
                string query = @"SELECT 
                                    UserID, 
                                    FullName, 
                                    Username, 
                                    PasswordHash, 
                                    Role, 
                                    IsActive, 
                                    CreatedAt 
                                 FROM Users";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt); // Fill DataTable
                dgvUsers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        // ================= VIEW BUTTON =================
        private void btnView_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        // ================= SELECT ROW =================
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgvUsers.CellClick += dgvUsers_CellClick;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["PasswordHash"].Value.ToString();
            }
        }

        // ================= UPDATE USER =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == 0)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            try
            {
                string query = @"UPDATE Users 
                                 SET FullName=@FullName, 
                                     Username=@Username, 
                                     PasswordHash=@PasswordHash 
                                 WHERE UserID=@UserID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@PasswordHash", txtPassword.Text);
                cmd.Parameters.AddWithValue("@UserID", selectedUserId);

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("User updated successfully!");
                LoadUsers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        // ================= CLEAR =================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            selectedUserId = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                // Insert query with parameters
                string query = @"INSERT INTO Users (FullName, Username, PasswordHash, Role, IsActive)
                         VALUES (@FullName, @Username, @PasswordHash, @Role, @IsActive)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@PasswordHash", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", "Executive"); // default role
                    cmd.Parameters.AddWithValue("@IsActive", 1); // default active

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("User added successfully!");
                LoadUsers();
                ClearFields();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint error
                    MessageBox.Show("Username already exists. Please choose another.");
                else
                    MessageBox.Show("Error adding user: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                if (selectedUserId == 0)
                {
                    MessageBox.Show("Please select a user to delete.");
                    return;
                }

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this user?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = "DELETE FROM Users WHERE UserID=@UserID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserID", selectedUserId);

                            if (conn.State == ConnectionState.Closed)
                                conn.Open();

                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }

                        MessageBox.Show("User deleted successfully!");
                        LoadUsers();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting user: " + ex.Message);
                    }
                }
            }
        }
    }
    
}
