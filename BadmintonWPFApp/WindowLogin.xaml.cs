using BusinessObject;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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
                int userId = login.UserId;
                List<int> roleIds = login.Roles.Select(u => u.RoleId).ToList();
                //Customer
                if (roleIds.Contains(1))
                {
                    Properties.Settings.Default.Email = email;
                    Properties.Settings.Default.RoleId = 1;
                    Properties.Settings.Default.UserId = login.UserId;
                    Properties.Settings.Default.Save();
                    MainWindow admin = new MainWindow();
                    admin.Show();
                    this.Close();

                }
                //Admin
                else if (roleIds.Contains(2))
                {
                    Properties.Settings.Default.Email = email;
                    Properties.Settings.Default.RoleId = 2;
                    Properties.Settings.Default.UserId = login.UserId;
                    Properties.Settings.Default.Save();
                    WindowAdmin main = new WindowAdmin();
                    main.Show();
                    this.Close();
                }
                //Manager
                else if (roleIds.Contains(3))
                {
                    Properties.Settings.Default.Email = email;
                    Properties.Settings.Default.RoleId = 3;
                    Properties.Settings.Default.UserId = login.UserId;
                    Properties.Settings.Default.Save();
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                //Staff
                else if (roleIds.Contains(4))
                {
                    Properties.Settings.Default.Email = email;
                    Properties.Settings.Default.RoleId = 4;
                    Properties.Settings.Default.UserId = login.UserId;
                    Properties.Settings.Default.Save();
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
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


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

    }
}
