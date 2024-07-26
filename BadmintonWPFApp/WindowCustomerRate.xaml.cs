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
    public partial class WindowCustomerRate : Window
    {
        private int _courtId;
        private readonly RatingObject _ratingObject;
        private readonly UserObject _userObject;

        public WindowCustomerRate(int courtId)
        {
            InitializeComponent();
            _courtId = courtId;
            _ratingObject = new RatingObject();
            _userObject = new UserObject();
            LoadCourt();

            // Add event handlers for star checkboxes
            Star1.Checked += Star_Checked;
            Star2.Checked += Star_Checked;
            Star3.Checked += Star_Checked;
            Star4.Checked += Star_Checked;
            Star5.Checked += Star_Checked;
        }

        private void LoadCourt()
        {
            DataContext = _ratingObject.getCourtDetail(_courtId);
        }

        private void Star_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox star = sender as CheckBox;
            int rating = int.Parse(star.Name.Substring(4));

            // Set all stars up to the selected one as checked
            for (int i = 1; i <= 5; i++)
            {
                CheckBox starCheckBox = FindName($"Star{i}") as CheckBox;
                if (starCheckBox != null)
                {
                    starCheckBox.IsChecked = i <= rating;
                }
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            int userid = _userObject.findByEmail(Properties.Settings.Default.Email).UserId;
            int ratingValue = 0;

            // Determine the rating value based on the selected star
            for (int i = 1; i <= 5; i++)
            {
                CheckBox starCheckBox = FindName($"Star{i}") as CheckBox;
                if (starCheckBox != null && starCheckBox.IsChecked == true)
                {
                    ratingValue = i;
                }
            }

            string review = ReviewTextBox.Text;
            Rating rating = new Rating()
            {
                CourtId = _courtId,
                UserId = userid,
                Rating1 = ratingValue,
                Review = review,
                CreatedAt = DateTime.Now,
            };

            _ratingObject.SubmitRating(rating);
            MessageBox.Show("Rating submitted.", "Rating", MessageBoxButton.OK, MessageBoxImage.None);
            this.Close();
        }
    }
}