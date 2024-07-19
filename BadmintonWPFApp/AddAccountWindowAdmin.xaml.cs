using BusinessObject;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BadmintonWPFApp
{
    /// <summary>
    /// Interaction logic for AddAccountWindowAdmin.xaml
    /// </summary>
    public partial class AddAccountWindowAdmin : Window
    {
        private readonly UserObject _userObject;
        public AddAccountWindowAdmin()
        {
            InitializeComponent();
            _userObject = new UserObject();
        }


        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            // Implement user creation logic here
            if (ValidateInput())
            {
                User newUser = new User
                {
                    UserName = txtUsername.Text,
                    Email = txtEmail.Text,
                    Password = pwbPassword.Password,
                    Status = true
                };
                _userObject.AddUserAdmin(newUser, chkAdmin.IsChecked == true, chkManager.IsChecked == true, chkStaff.IsChecked == true, chkCustomer.IsChecked == true);

                MessageBox.Show("User added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool ValidateInput()
        {
            StringBuilder errorMessage = new StringBuilder();

            // Check if username is not empty
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorMessage.AppendLine("Username is required.");
            }
            else if (_userObject.findByUserName(txtUsername.Text) != null)
            {
                errorMessage.AppendLine("Username already taken");
            }

            // Check if email is not empty and is valid
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorMessage.AppendLine("Email is required.");
            }
            else if (_userObject.findByEmail(txtEmail.Text) != null)
            {
                errorMessage.AppendLine("Email already registered.");
            }
            else if (!IsValidEmail(txtEmail.Text))
            {
                errorMessage.AppendLine("Please enter a valid email address.");
            }

            // Check if password is not empty
            if (string.IsNullOrWhiteSpace(pwbPassword.Password))
            {
                errorMessage.AppendLine("Password is required.");
            }

            if (string.IsNullOrWhiteSpace(pwbConfirmPassword.Password))
            {
                errorMessage.AppendLine("Confirm password is required.");
            }


            // Check if password and confirm password match
            if (pwbPassword.Password != pwbConfirmPassword.Password)
            {
                errorMessage.AppendLine("Passwords do not match.");
            }

            // Check if at least one role is selected
            if (!(chkAdmin.IsChecked == true || chkManager.IsChecked == true ||
                  chkStaff.IsChecked == true || chkCustomer.IsChecked == true))
            {
                errorMessage.AppendLine("Please select at least one role.");
            }

            // If there are any error messages, display them and return false
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage.ToString(), "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            WindowAccountManagement windowAccountManagement = new WindowAccountManagement();
            windowAccountManagement.Show();
            this.Close();
        }
    }
}
