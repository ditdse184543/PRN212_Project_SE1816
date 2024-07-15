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
    /// Interaction logic for WindowCustomerRate.xaml
    /// </summary>
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

        }
        private void LoadCourt()
        {
            DataContext = _ratingObject.getCourtDetail(_courtId);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
          int userid=  _userObject.findByEmail(Properties.Settings.Default.Email).UserId;
            int ratingValue = 0;
            if (RatingComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a rating.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; 
            }
            if (RatingComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                ratingValue = int.Parse(selectedItem.Content.ToString());
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
