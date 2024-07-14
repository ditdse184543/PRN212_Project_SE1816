using BusinessObject;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BadmintonWPFApp
{
    public partial class BookingWindow : Window
    {
        private readonly BookingObject bookingObject;

        public BookingWindow()
        {
            InitializeComponent();
            bookingObject = new BookingObject();
            InitializeTimeSlots();
        }

        private void InitializeTimeSlots()
        {
            TimeSlotComboBox.Items.Clear();
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
            
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            string date = BookingDatePicker.SelectedDate?.ToString("MM/dd/yyyy") ?? "No date selected";
            string timeSlot = (TimeSlotComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "No time slot selected";
            string playerName = PlayerNameTextBox.Text;

            
            Booking booking = new Booking
            {
                BBookingType = "Casual",
                CoId = 1,
                UserId = 1,

            };
            TimeSlot slot = new TimeSlot
            {
                BId = 1,
                CoId = 1,
                TsCheckedIn = false,
                TsDate = DateOnly.FromDateTime(BookingDatePicker.SelectedDate.Value),
                TsTime = timeSlot
            };

            bookingObject.Insert(booking);

            string bookingDisplay = $"{date} - {timeSlot} - {playerName}";
            BookingsListBox.Items.Add(bookingDisplay);

            // Clear input fields
            BookingDatePicker.SelectedDate = null;
            TimeSlotComboBox.SelectedItem = null;
            PlayerNameTextBox.Clear();
        }
    }
}
