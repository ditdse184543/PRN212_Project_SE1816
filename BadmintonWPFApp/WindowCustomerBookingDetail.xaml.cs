using BusinessObject;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace BadmintonWPFApp
{
    /// <summary>
    /// Interaction logic for WindowCustomerBookingDetail.xaml
    /// </summary>
    /// 
    public partial class WindowCustomerBookingDetail : Window
    {
        private readonly BookingObject _bookingObject;
        private readonly UserObject _userObject;
        private int _courtId;
        public WindowCustomerBookingDetail(int courtId)
        {
            InitializeComponent();
            _bookingObject = new BookingObject();
            _userObject = new UserObject();
            _courtId = courtId;
            LoadBookingDetailBasedOnCourt();
        }
       
        private void LoadBookingDetailBasedOnCourt()
        {
           string mail= Properties.Settings.Default.Email;
            var user=_userObject.findByEmail(mail).UserId;
            BookingCusDataGrid.ItemsSource = _bookingObject.showListBookingBasedOnCourt(_courtId, user);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string mail = Properties.Settings.Default.Email;
            var user = _userObject.findByEmail(mail).UserId;
            string search = txtSearch.Text;
           
            BookingCusDataGrid.ItemsSource = _bookingObject.SearchBooking(search, _courtId, user);
        }
    }
}
