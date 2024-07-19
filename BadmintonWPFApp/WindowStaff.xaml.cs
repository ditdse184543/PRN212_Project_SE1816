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
    /// Interaction logic for WindowStaff.xaml
    /// </summary>
    public partial class WindowStaff : Window
    {
        public WindowStaff()
        {
            InitializeComponent();
        }

        private void Button_Checkin(object sender, RoutedEventArgs e)
        {
            WindowCheckIn WindowCheckIn = new WindowCheckIn();
            WindowCheckIn.Show();
            this.Close();
        }

        private void Button_Report(object sender, RoutedEventArgs e)
        {
            CourtReportListQualityW windowReport = new CourtReportListQualityW();
            windowReport.Show();
            this.Close();
        }
    }
}
