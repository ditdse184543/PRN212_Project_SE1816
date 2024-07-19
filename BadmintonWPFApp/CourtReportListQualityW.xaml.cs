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
    /// Interaction logic for CourtReportListQualityW.xaml
    /// </summary>
    public partial class CourtReportListQualityW : Window
    {
        private CourtObject CourtObject;
        public CourtReportListQualityW()
        {
            InitializeComponent();
            CourtObject = new CourtObject();
            Loaded += Loading;
        }


        private void Reportbtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            try
            {
                if (button != null)
                {
                    int courtid = (int)button.Tag;
                    WindowReport windowReport = new WindowReport(courtid);
                    windowReport.Show();
                    this.Close();
                    //Court room = button.DataContext as Court;
                    //if (room != null)
                    //{
                    //    lvData.SelectedItem = room;
                    //    Court selectedRoom = lvData.SelectedItem as Court;
                    //    Properties.Settings.Default.CourtId = selectedRoom.CoId;
                    //    Properties.Settings.Default.Save();
                    //    BookingWindow windowOrderBooking = new BookingWindow();
                    //    windowOrderBooking.Closed += LoadingAgain;
                    //    windowOrderBooking.Show();
                    //}
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void Loading(object sender, RoutedEventArgs e)
        {
            lvData.ItemsSource = CourtObject.GetAll();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchTextBox.Text.Trim();
            lvData.ItemsSource = CourtObject.GetCourtBySearch(search);

        }

        private void lvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
        private void LoadingItem()
        {
            lvData.ItemsSource = CourtObject.GetAll();


        }
        private void LoadingAgain(object? sender, EventArgs e)
        {
            LoadingItem();
        }
    }
}
