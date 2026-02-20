using System;
using System.Windows.Forms;
using RetailIQAnalytics.ServiceLayer;

namespace RetailIQAnalytics.UI
{
    public partial class RegisterForm : Form
    {
        private UserService userService = new UserService();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = userService.Register(username, password, fullName);
            if (success)
            {
                MessageBox.Show("Registration successful! Please login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open login page
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Close the register form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Registration failed! Username might already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();   
            loginForm.Show();
        }
    }
}
