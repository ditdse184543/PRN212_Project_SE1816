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
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        private readonly BookingObject bookingObject;
        private readonly TimeSlotObject timeSlotObject;
        private List<TimeSlot> timeSlots = new List<TimeSlot>();
        public BookingWindow()
        {
            InitializeComponent();
            bookingObject = new BookingObject();
            timeSlotObject = new TimeSlotObject();
            InitializeTimeSlots();
            BookingDatePicker.SelectedDate = DateTime.Today;
        }

        private void AddPromptComboBox()
        {
            var promptItem = new ComboBoxItem
            {
                Content = "Choose your time",
                IsEnabled = false,
                IsSelected = true
            };
            TimeSlotComboBox.Items.Add(promptItem);
        }
        private void InitializeTimeSlots()
        {
            TimeSlotComboBox.Items.Clear();
            AddPromptComboBox();
            TimeSlotComboBox.Items.Add("9:00 AM - 10:00 AM");
            TimeSlotComboBox.Items.Add("10:00 AM - 11:00 AM");
            TimeSlotComboBox.Items.Add("11:00 AM - 12:00 PM");
            TimeSlotComboBox.Items.Add("12:00 PM - 1:00 PM");
            TimeSlotComboBox.Items.Add("1:00 PM - 2:00 PM");
            TimeSlotComboBox.Items.Add("2:00 PM - 3:00 PM");
            TimeSlotComboBox.Items.Add("3:00 PM - 4:00 PM");
            TimeSlotComboBox.Items.Add("4:00 PM - 5:00 PM");
        }


        private void BookingDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookingDatePicker.SelectedDate.HasValue)
            {
                DateOnly selectedDate = DateOnly.FromDateTime(BookingDatePicker.SelectedDate.Value);
                List<TimeSlot> slots = timeSlotObject.getByDate(selectedDate);

                InitializeTimeSlots();

                foreach (var slot in slots)
                {
                    for (int i = TimeSlotComboBox.Items.Count - 1; i >= 0; i--)
                    {
                        if (TimeSlotComboBox.Items[i].ToString() == slot.TsTime)
                        {
                            TimeSlotComboBox.Items.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }


        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            string timeSlot = TimeSlotComboBox.SelectedItem?.ToString() ?? "No time slot selected";
            string playerName = PlayerNameTextBox.Text;

            TimeSlot slot = new TimeSlot
            {
                CoId = 2,
                TsCheckedIn = false,
                TsDate = DateOnly.FromDateTime(BookingDatePicker.SelectedDate.Value),
                TsTime = timeSlot
            };
            timeSlots.Add(slot);

            string bookingDisplay = $"{BookingDatePicker.SelectedDate} - {timeSlot} - {playerName}";
            BookingsListBox.Items.Add(bookingDisplay);

            // Clear input fields
            BookingDatePicker.SelectedDate = null;
            TimeSlotComboBox.SelectedIndex = 0;
            PlayerNameTextBox.Clear();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            timeSlots.Clear();
            BookingsListBox.ItemsSource = null;
            BookingDatePicker.SelectedDate = null;
            TimeSlotComboBox.SelectedIndex = 0;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking
            {
                CoId= 2,
                BBookingType = "Casual",
                UserId = 1,
            };
            foreach(TimeSlot slot  in timeSlots)
            {
                booking.TimeSlots.Add(slot);
            }
            if (MessageBox.Show("Are you certain with your decision?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                bookingObject.Insert(booking);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
