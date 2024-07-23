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
                txtAddress.Text = selectedCourt.CoAddress;
                txtInfo.Text = selectedCourt.CoInfo;
                txtPrice.Text = selectedCourt.CoPrice.ToString();
                txtImagePath.Text = selectedCourt.CoPath;
                txtId.Text = selectedCourt.CoId.ToString();
                // Display the image in the Image control
                if (!string.IsNullOrEmpty(selectedCourt.CoPath))
                {
                    string absolutePath = selectedCourt.AbsoluteCoPath;
                    if (File.Exists(absolutePath))
                    {
                        imagePicture.Source = new BitmapImage(new Uri(absolutePath));
                    }
                    else
                    {
                        // Handle the case where the file does not exist
                        imagePicture.Source = null;
                        MessageBox.Show("Image file not found.", "File Not Found", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    imagePicture.Source = null;
                }

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

                try
                {
                    // Create a BitmapImage and load the image from the file stream
                    BitmapImage bitmap = new BitmapImage();
                    using (FileStream stream = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                    {
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.StreamSource = stream;
                        bitmap.EndInit();
                    }

                    // Set the image source
                    imagePicture.Source = bitmap;

                    // Set the txtImagePath TextBox with the selected file path
                    txtImagePath.Text = selectedFilePath;
                    isImageSaved = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading the image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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

                // Generate a unique file name using a GUID
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + System.IO.Path.GetFileName(selectedFilePath);

                // Define the destination path for the selected image with the unique file name
                string destinationPath = System.IO.Path.Combine(imagesFolder, uniqueFileName);

                try
                {
                    // Copy the selected image to the Images folder with the unique file name
                    File.Copy(selectedFilePath, destinationPath, true);

                    // Save the relative path in the TextBox
                    string relativeImagePath = System.IO.Path.Combine("Images", uniqueFileName);
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
            // Check if the ID textbox has a value greater than 0
            if (int.TryParse(txtId.Text, out int id) && id > 0)
            {
                // If ID is already set (greater than 0), notify the user to refresh
                MessageBox.Show("Please refresh before creating a new record.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
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
            dataGridAdminCourt.SelectedItem = null;
            txtId.Text = null;
            txtName.Text = null;
            txtAddress.Text = null;
            txtInfo.Text = null;
            txtPrice.Text = null;
            txtImagePath.Text = null;
            imagePicture.Source = null;
            selectedCourtId = 0; // Reset selectedCourtId
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCourtId == null || selectedCourtId == 0)
            {
                MessageBox.Show("Id not found", "Delete court", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var check = _courtObject.GetCourt(selectedCourtId);
            if (check.CoStatus == false)
            {
                MessageBox.Show("Court already deleted", "Delete court", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show(
      "Are you sure you want to delete this court?",
      "Confirm Delete",
      MessageBoxButton.YesNo,
      MessageBoxImage.Question
  );
            if (result == MessageBoxResult.Yes)
            {
                int id = selectedCourtId;
                _courtObject.Delete(id);
                MessageBox.Show("Deleted court successfully", "Delete court", MessageBoxButton.OK, MessageBoxImage.None);
                LoadCourt();
            }
            else
            {
                MessageBox.Show("Delete operation canceled.", "Canceled", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCourtId == null || selectedCourtId == 0)
            {
                MessageBox.Show("Id not found", "Update court", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Court model = _courtObject.GetCourt(selectedCourtId);
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDirectory, @"..\..\.."));
            string imagesFolder = System.IO.Path.Combine(projectDirectory, "Images");


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
            // Check if a new image was selected
      /*      if (model.CoPath != null && model.CoPath != txtImagePath.Text)
            {
                string existingImagePath = System.IO.Path.Combine(imagesFolder, System.IO.Path.GetFileName(model.CoPath));

                if (System.IO.File.Exists(existingImagePath))
                {
                    try
                    {
                        
                        using (var fileStream = new FileStream(existingImagePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            // Optionally, load the image to ensure the file is not locked
                            var image = System.Drawing.Image.FromStream(fileStream);
                            image.Dispose();
                        }

                        // Attempt to delete the existing image file
                        System.IO.File.Delete(existingImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting the image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            } */


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
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;
            dataGridAdminCourt.ItemsSource = _courtObject.SearchCourt(search);
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {

            MainWindow window = new MainWindow();
            window.Show();
            this.Close();


        }

    }

   
}

