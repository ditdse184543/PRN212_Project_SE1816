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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private readonly UserObject _userObject;
        public WindowLogin()
        {
            InitializeComponent();
            _userObject = new UserObject();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPassword.Password;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Please fill in all fields", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            User login = _userObject.Login(email, pass);
            if (login != null)
            {
                List<int> roleIds = login.Roles.Select(u => u.RoleId).ToList();
                if (roleIds.Contains(1))
                {
                    WindowAdmin admin = new WindowAdmin();
                    admin.Show();
                    this.Close();
                }
                else if (roleIds.Contains(2) || roleIds.Contains(3))
                {
                    WindowCourt court = new WindowCourt();
                    court.Show();
                    this.Close();
                }
                Properties.Settings.Default.Email = email;
            }
            else
            {
                MessageBox.Show("Wrong username or password", "Login", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            WindowRegister register = new WindowRegister();
            register.Show();
            this.Close();
        }

    }
}
