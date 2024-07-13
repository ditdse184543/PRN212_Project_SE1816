using BusinessObject;
using DataAccess.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Interaction logic for WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        private bool isImageSaved = false;
        private readonly CourtObject _courtObject;
        private readonly UserObject _userObject;
        private int selectedCourtId;
        private bool status;
        public WindowAdmin()
        {
            InitializeComponent();
            _courtObject = new CourtObject();   
            _userObject = new UserObject();
            LoadCourt();
        }
        //for crud
        private void dataGridAdminCourt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridAdminCourt.SelectedItem != null)
            {

                Court selectedCourt = (Court)dataGridAdminCourt.SelectedItem;
                selectedCourtId = selectedCourt.CoId;
                txtName.Text = selectedCourt.CoName;
                txtAddress.Text= selectedCourt.CoAddress;
                txtInfo.Text = selectedCourt.CoInfo;
                txtPrice.Text = selectedCourt.CoPrice.ToString();
                txtImagePath.Text = selectedCourt.CoPath;
                // Display the image in the Image control
                imagePicture.Source = new BitmapImage(new Uri(selectedCourt.AbsoluteCoPath));

                status = selectedCourt.CoStatus;

            }
        }

            private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;

                // Display the image in the Image control
                imagePicture.Source = new BitmapImage(new Uri(selectedFilePath));

                // Set the txtImagePath TextBox with the selected file path
                txtImagePath.Text = selectedFilePath;
                isImageSaved = false;
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string selectedFilePath = txtImagePath.Text;

            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                // Get the application's base directory
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string projectDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDirectory, @"..\..\.."));

                // Define the Images folder path within the project directory
                string imagesFolder = System.IO.Path.Combine(projectDirectory, "Images");

                // Ensure the Images folder exists
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                // Define the destination path for the selected image
                string destinationPath = System.IO.Path.Combine(imagesFolder, System.IO.Path.GetFileName(selectedFilePath));

                try
                {
                    // Copy the selected image to the Images folder
                    File.Copy(selectedFilePath, destinationPath, true);

                    // Save the relative path in the TextBox
                    string relativeImagePath = System.IO.Path.Combine("Images", System.IO.Path.GetFileName(selectedFilePath));
                    txtImagePath.Text = relativeImagePath;
                    MessageBox.Show("Image saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    isImageSaved = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while copying the file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an image to save.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            string info = txtInfo.Text;
            string price = txtPrice.Text;
            string imagePath = txtImagePath.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(info) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Please input all fields", "Create court", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(price, out double priceCheck))
            {
                MessageBox.Show("Please enter a valid number for the price.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!isImageSaved)
            {
                MessageBox.Show("Please save the uploaded image before creating the court.", "Create court", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var user = _userObject.findByEmail(Properties.Settings.Default.Email);
            Court add = new Court()
            {
                CoName = name,
                CoAddress = address,
                CoInfo = info,
                CoPrice = priceCheck,
                CoPath = imagePath,
                CoStatus = true,
                UserId = user.UserId,
            };

            _courtObject.AddCourt(add);
            MessageBox.Show("Added court successfully", "Create court", MessageBoxButton.OK, MessageBoxImage.None);
            Reload();
            LoadCourt();
        }

        private void LoadCourt()
        {
            var courts = _courtObject.GetAll();

            // Set the ItemsSource of the DataGrid
            dataGridAdminCourt.ItemsSource = courts;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadCourt();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCourtId==null)
            {
                MessageBox.Show("Id not found", "Delete court", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int id = selectedCourtId;
            _courtObject.Delete(id);
            MessageBox.Show("Deleted court successfully", "Delete court", MessageBoxButton.OK, MessageBoxImage.None);
            Reload();
            LoadCourt();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            string info = txtInfo.Text;
            string price = txtPrice.Text;
            string imagePath = txtImagePath.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(info) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Please input all fields", "Create court", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(price, out double priceCheck))
            {
                MessageBox.Show("Please enter a valid number for the price.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
           
            var user = _userObject.findByEmail(Properties.Settings.Default.Email);
            
            Court update = new Court()
            {
                CoId = selectedCourtId,  // Use the stored court ID
                CoName = name,
                CoAddress = address,
                CoInfo = info,
                CoPrice = priceCheck,
                CoPath = imagePath,
                CoStatus = status,
                UserId = user.UserId,
            };

            _courtObject.Update(update);  // Assuming you have an UpdateCourt method in your CourtObject class
            MessageBox.Show("Updated court successfully", "Update court", MessageBoxButton.OK, MessageBoxImage.None);
            MessageBox.Show("Image path should be /Image/abc.png", "Image", MessageBoxButton.OK, MessageBoxImage.Information);
            Reload();
            LoadCourt();



        }
        private void Reload()
        {
            txtName.Text = null;
            txtAddress.Text = null;
            txtInfo.Text = null;
            txtPrice.Text = null;
            txtImagePath.Text = null;
            imagePicture.Source = null;
        }

    }
}

