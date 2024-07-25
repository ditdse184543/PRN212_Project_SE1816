using BusinessObject;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BadmintonWPFApp
{
    /// <summary>
    /// Interaction logic for WindowCustomer.xaml
    /// </summary>
    public partial class WindowCustomer : Window
    {
        private readonly UserObject _useObject;
        private readonly CourtObject _courtObject;
        public WindowCustomer()
        {
            InitializeComponent();
            _useObject = new UserObject();
            _courtObject=new CourtObject();
            LoadCourt();
        }
        private void LoadCourt()
        {
            string mail = Properties.Settings.Default.Email;
            var userId =_useObject.findByEmail(mail);
            BookingCusDataGrid.ItemsSource = _courtObject.LoadCourtBasedOnBooking(userId.UserId);

        }



        private void btnBookingDetail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int courtId = (int)button.CommandParameter;

                WindowCustomerBookingDetail window = new WindowCustomerBookingDetail(courtId);
                window.Show();

            }
        }

            private void btnRate_Click(object sender, RoutedEventArgs e)
            {
            Button button = sender as Button;
            if (button != null)
            {
                int courtId = (int)button.CommandParameter;

                WindowCustomerRate window = new WindowCustomerRate(courtId);
                window.Show();

            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }
    }
}
