using BusinessObject;
using DataAccess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
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

    public partial class WindowCourt : Window
    {
        private CourtObject CourtObject;

        public WindowCourt()
        {
            InitializeComponent();
            CourtObject = new CourtObject();
            Loaded += Loading;
        }

        private void Loading(object sender, RoutedEventArgs e)
        {
            lvData.ItemsSource = CourtObject.GetAll();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchTextBox.Text.Trim();
            lvData.ItemsSource = CourtObject.GetCourtBySearch(search);

        }

        private void lvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Bookbtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            try
            {
                if (button != null)
                {
                    Court room = button.DataContext as Court;
                    if (room != null)
                    {
                        lvData.SelectedItem = room;
                        Court selectedRoom = lvData.SelectedItem as Court;
                        Properties.Settings.Default.CourtId = selectedRoom.CoId;
                        Properties.Settings.Default.UserId = selectedRoom.UserId;
                        Properties.Settings.Default.Save();
                        BookingWindow windowOrderBooking = new BookingWindow();
                        windowOrderBooking.Closed += LoadingAgain;
                        windowOrderBooking.Show();
                        
                       
                    }
                }
            }
            catch (Exception ex)
            {

            }
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
