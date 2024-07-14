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
    /// Interaction logic for WindowCheckIn.xaml
    /// </summary>
    public partial class WindowCheckIn : Window
    {
        private readonly TimeSlotObject timeSlotObject;
        public WindowCheckIn()
        {
            InitializeComponent();
            Loaded += Ts_Loaded;
            timeSlotObject = new TimeSlotObject();
        }

        private void Ts_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTSist();
        }

        private void LoadTSist()
        {
            try
            {
                var tsList = timeSlotObject.GetAllTimeSlots().
                    Select(ts => new
                    {
                        TS_ID = ts.TsId,
                        CO_Name = ts.Co.CoName,
                        B_ID = ts.BIdNavigation.BId,
                        TS_Date = ts.TsDate,
                        TsTime = ts.TsTime,
                        TS_Checked_in = ts.TsCheckedIn
                    }).ToList();
                BookedTimeSLotDataGrid.ItemsSource = tsList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ReloadTsButton_Click(object sender, RoutedEventArgs e)
        {
            LoadTSist();
        }

        private void CheckinButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int TsId = (int)button.Tag;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to check in?", "Confirm Check-in", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    timeSlotObject.Checkin(TsId);
                    MessageBox.Show("Check-in successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadTSist();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during check-in: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SearchTSButton_Click(object sender, RoutedEventArgs e)
        {
            string searchValue = SearchTsTB.Text;
            if (int.TryParse(searchValue, out int bookingID))
            {
                try
                {
                    var tsList = timeSlotObject.GetAllTimeSlots()
                        .Where(ts => ts.BIdNavigation.BId == bookingID)
                        .Select(ts => new
                        {
                            TS_ID = ts.TsId,
                            CO_Name = ts.Co.CoName,
                            B_ID = ts.BIdNavigation.BId,
                            TS_Date = ts.TsDate,
                            TsTime = ts.TsTime,
                            TS_Checked_in = ts.TsCheckedIn
                        }).ToList();

                    if (tsList.Any())
                    {
                        BookedTimeSLotDataGrid.ItemsSource = tsList;
                    }
                    else
                    {
                        MessageBox.Show($"No time slots found for Booking ID: {bookingID}", "No Results", MessageBoxButton.OK, MessageBoxImage.Information);
                        BookedTimeSLotDataGrid.ItemsSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error searching for time slots: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Booking ID (numeric value).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
