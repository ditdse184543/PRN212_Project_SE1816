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

namespace BadmintonWPFApp
{
    /// <summary>
    /// Interaction logic for WindowCheckedIn.xaml
    /// </summary>
    public partial class WindowCheckedIn : Window
    {
        private readonly TimeSlotObject timeSlotObject;
        public WindowCheckedIn()
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

        private void ReloadACButton_Click(object sender, RoutedEventArgs e)
        {

            LoadTSist();
        }

        //private void SearchACButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string searchValue = SearchACTextBox.Text;
        //    List<AirConditioner> searchResult = null;
        //    if (int.TryParse(searchValue, out int quantity))
        //    {
        //        searchResult = airConditionerObjects.SearchAirConditioners(null, quantity);
        //    }
        //    else
        //    {
        //        searchResult = airConditionerObjects.SearchAirConditioners(searchValue, null);
        //    }
        //    var acList = searchResult.Select(x => new
        //    {
        //        AirConditionerId = x.AirConditionerId,
        //        AirConditionerName = x.AirConditionerName,
        //        Warranty = x.Warranty,
        //        SoundPressureLevel = x.SoundPressureLevel,
        //        FeatureFunction = x.FeatureFunction,
        //        Quantity = x.Quantity,
        //        DollarPrice = x.DollarPrice,
        //        SupplierName = x.Supplier.SupplierName
        //    }).ToList();
        //    ACDataGrid.ItemsSource = acList;
        //}
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
    }
}
