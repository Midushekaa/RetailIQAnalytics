using System;
using System.Windows.Forms;
using RetailIQAnalytics.ServiceLayer;

namespace RetailIQAnalytics.UI
{
    public partial class LoginForm : Form
    {
        private UserService userService = new UserService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userService.Login(username, password, out string role))
            {
                MessageBox.Show($"Login successful! Role: {role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                ExecutiveDashboardForm dashboard = new ExecutiveDashboardForm();
                dashboard.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

    }
}
