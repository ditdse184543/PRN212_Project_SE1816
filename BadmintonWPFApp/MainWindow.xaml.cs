using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BadmintonWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckLoginBtnStatus();
            CheckRolePermissions(); 
        }

        private void CheckLoginBtnStatus()
        {
            int userId = Properties.Settings.Default.UserId;
            if (userId > 0)
            {
                TreeViewItem loginItem = FindTreeViewItem("Login");
                if (loginItem != null)
                {
                    loginItem.Visibility = Visibility.Collapsed;
                }
            }
            if (userId == 0)
            {
                TreeViewItem logoutItem = FindTreeViewItem("Logout");
                if (logoutItem != null)
                {
                    logoutItem.Visibility = Visibility.Collapsed;
                }
            }
        }
        private TreeViewItem FindTreeViewItem(string header)
        {
            foreach (TreeViewItem item in myTreeView.Items)
            {
                if (item.Header is StackPanel stackPanel)
                {
                    foreach (var child in stackPanel.Children)
                    {
                        if (child is TextBlock textBlock && textBlock.Text == header)
                        {
                            return item;
                        }
                    }
                }
            }
            return null;
        }
        private void CheckRolePermissions()
        {
            int role = Properties.Settings.Default.RoleId;
            if (role != 3)
            {
                dashboardItem.Visibility = Visibility.Collapsed;
            }
            if (role != 2 && role !=3)
            {
                manageCourtItem.Visibility = Visibility.Collapsed;
            }
            if(role != 1)
            {
                CustomerItem.Visibility = Visibility.Collapsed;
            }
            if (role != 2)
            {
                ManageAccountItem.Visibility = Visibility.Collapsed;
            }
            if (role != 4)
            {
                StaffFuncItem.Visibility = Visibility.Collapsed;
            }
            if (role == 1) //Customer
            {
                TitleBooking.Text = "Booking Court";
            }
            else if(role == 2) //Admin
            {
                TitleBooking.Text = "Booking Workplace for Admin";
            }
            else if (role == 3) //Maanager
            {
                TitleBooking.Text = "Booking Workplace for Manager";
            }
            else if (role == 4) //Staff
            {
                TitleBooking.Text = "Booking Workplace for Staff";
            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                if (e.NewValue is TreeViewItem selectedItem)
                {
                    if (selectedItem.Header is StackPanel stackPanel && stackPanel.Children.OfType<TextBlock>().FirstOrDefault() is TextBlock textBlock)
                    {
                        if (textBlock.Text == "Logout")
                        {
                            MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (result == MessageBoxResult.Yes)
                            {
                                Properties.Settings.Default.Email = string.Empty;
                                Properties.Settings.Default.UserId = 0;
                                Properties.Settings.Default.RoleId = 0;
                                var newWindow = new MainWindow();
                                newWindow.Show();
                                Properties.Settings.Default.Save();
                                this.Close();
                            }
                        }
                        else if (textBlock.Text == "Booking")
                        {
                            var newWindow = new WindowCourt();
                            newWindow.Show();
                            this.Close();
                        }
                        else if (textBlock.Text == "Manage court")
                        {
                            int role = Properties.Settings.Default.RoleId;
                            if (role != 3)
                            {
                                throw new Exception("You aren't permited to access this function!!");
                            }
                            var bookingReservationWindow = new WindowAdmin();
                            bookingReservationWindow.Show();
                            this.Close();
                        }
                        else if (textBlock.Text == "Dashboard")
                        {
                            int role = Properties.Settings.Default.RoleId;
                            if (role != 3)
                            {
                                throw new Exception("You aren't permited to access this function!!");
                            }
                            var dashBoard = new WindowDashBoard();
                            dashBoard.Show();
                            this.Close();
                        }
                        else if (textBlock.Text == "Manage Account")
                        {
                            var newWindow = new WindowAccountManagement();
                            newWindow.Show();
                            this.Close();
                        }
                        else if (textBlock.Text == "Staff")
                        {
                            var newWindow = new WindowStaff();
                            newWindow.Show();
                            this.Close();
                        }
                        else if (textBlock.Text == "Your Booking")
                        {
                            var newWindow = new WindowCustomer();
                            newWindow.Show();
                            this.Close();
                        }
                        else if (textBlock.Text == "Checkin")
                        {
                            var newWindow = new WindowStaff();
                            newWindow.Show();
                            this.Close();
                        }
                        else if (textBlock.Text == "Login")
                        {
                            var profileScreen = new WindowLogin();
                            profileScreen.Show();
                            this.Close();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}