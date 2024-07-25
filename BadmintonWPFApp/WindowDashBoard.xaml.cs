using BusinessObject;
using DataAccess.Models;
using LiveCharts.Wpf;
using LiveCharts;
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
using LiveCharts.Wpf.Charts.Base;
using Microsoft.IdentityModel.Tokens;

namespace BadmintonWPFApp
{
    /// <summary>
    /// Interaction logic for WindowDashBoard.xaml
    /// </summary>
    public partial class WindowDashBoard : Window
    {
        private readonly CourtObject courtObject;
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        public WindowDashBoard()
        {
            InitializeComponent();
            courtObject = new CourtObject();
            Loaded += WindowDashBoard_Loaded;
        }

        private void WindowDashBoard_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            DataContext = this; // Ensure DataContext is set after LoadData
        }

        private void LoadData()
        {
            // Fetch the booking data
            List<Court> courts = courtObject.getAllPaymentByUserId(6);
            if (courts.IsNullOrEmpty())
            {
                MessageBox.Show("null roi");
            }

            // Aggregate payment amounts for each booking
            var paymentData = courts.Select(c => new
            {
                CourtName = c.CoName,
                TotalAmount = c.Bookings.SelectMany(b => b.Payments).Sum(p => p.PAmount)
            }).ToList();

            // Initialize the SeriesCollection with the payment data
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Payments",
                    Values = new ChartValues<decimal>(paymentData.Select(d => d.TotalAmount))
                }
            };

            // Set the labels for the X-axis
            Labels = paymentData.Select(d => d.CourtName).ToList();
            // Format the Y-axis values as currency
            Formatter = value => value.ToString("C");
        }
    }
}
