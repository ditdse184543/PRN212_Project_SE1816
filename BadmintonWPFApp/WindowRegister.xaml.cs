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

namespace BadmintonWPFApp
{
    /// <summary>
    /// Interaction logic for WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        private readonly UserObject _userObject;
        public WindowRegister()
        {
            InitializeComponent();
            _userObject = new UserObject();

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string pass = txtPassword.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Please fill in all fields", "Register", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }else if (_userObject.findByEmail(email) != null)
            {
                 MessageBox.Show("Email already registered", "Register", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
            }else if(_userObject.findByUserName(username) != null)
            {
                MessageBox.Show("Username already taken", "Register", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            User model = new User()
            {
                UserName = username,
                Password = pass,
                Email = email
            };
            _userObject.Register(model);
            MessageBox.Show("Registered successfully");
            MainWindow main  = new MainWindow();
            main.Show();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            WindowLogin login = new WindowLogin();
            login.Show();
            this.Close();
        }
    }
}
