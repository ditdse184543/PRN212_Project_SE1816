using BusinessObject;
using DataAccess.Models;
using DataAccess.Repository;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BadmintonWPFApp
{
    /// <summary>
    /// Interaction logic for WindowAccountManagement.xaml
    /// </summary>
    public partial class WindowAccountManagement : Window
    {
        private readonly UserObject userObject;
        private readonly RoleObject roleObject;
        private readonly InvoiceObject invoiceObject;
        public WindowAccountManagement()
        {
            InitializeComponent();
            userObject = new UserObject();
            Loaded += AC_Loaded;
            roleObject = new RoleObject();
            invoiceObject = new InvoiceObject();
        }

        private void AC_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var data = userObject.forDataGrid().Where(x => x.Status == true).Select(x => new
            {
                UserID = x.UserId,
                UserName = x.UserName,
                Roles = x.Roles,
                Email = x.Email,
                Status = x.Status,
                Password = x.Password
            }).ToList();

            ACDataGrid.ItemsSource = data;
        }

        private void SearchACButton_Click(object sender, RoutedEventArgs e)
        {
            string searchValue = SearchACTextBox.Text;
            
        }

        private void AddACButton_Click(object sender, RoutedEventArgs e)
        {
            AddAccountWindowAdmin addAccountWindowAdmin = new AddAccountWindowAdmin();
            addAccountWindowAdmin.Show();
            this.Close();
        }

        private void ReloadACButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void UpdateACButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void DeleteACButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = (int)button.Tag;

            if(MessageBox.Show("Delete the Account?","Confirm Delete",MessageBoxButton.YesNo,MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                userObject.Delete(id);
                LoadData();
            }
        }

        private void AddNewRoleButton_Click(object sender, RoutedEventArgs e)
        {
            string newRoleName = NewRoleTextBox.Text.Trim();

            if (string.IsNullOrEmpty(newRoleName))
            {
                MessageBox.Show("Please enter a role name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string normalized = newRoleName.ToLower();
            bool roleExists = false;

            foreach (Role r in roleObject.GetAllRoles())
            {
                if (normalized == r.RoleName.ToLower())
                {
                    roleExists = true;
                    break;
                }
            }

            if (roleExists)
            {
                MessageBox.Show("A role with this name already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    var newRole = new Role { RoleName = newRoleName };
                    roleObject.addRole(newRole);

                    MessageBox.Show("New role added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    NewRoleTextBox.Clear();
                    LoadData(); // Reload the data to reflect the changes
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while adding the role: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Test_Invoice(object sender, RoutedEventArgs e)
        {
            InvoiceW invoiceW = new InvoiceW(invoiceObject.CreateInvoice(2));
            invoiceW.Show();
            this.Close();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }
    }
}

 