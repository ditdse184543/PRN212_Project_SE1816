using BusinessObject;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BadmintonWPFApp
{
    public partial class BookingWindow : Window
    {
        private readonly BookingObject bookingObject;
        private readonly TimeSlotObject timeSlotObject;
        private List<TimeSlot> timeSlots = new List<TimeSlot>();
        private ComboBox fixedBooking = new ComboBox();
        private ComboBox flexibleBooking = new ComboBox();
        private Dictionary<DateOnly, List<string>> disabledTimeSlots = new Dictionary<DateOnly, List<string>>();
        string type;

        public BookingWindow()
        {
            InitializeComponent();
            bookingObject = new BookingObject();
            timeSlotObject = new TimeSlotObject();
            InitializeTimeSlots();
            BookingDatePicker.SelectedDate = DateTime.Today;
            TypeComboBox.SelectedIndex = 0;

            fixedBooking.SelectionChanged += FixedBooking_SelectionChanged;
            flexibleBooking.SelectionChanged += FlexibleBooking_SelectionChanged;
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeComboBox.SelectedItem == null)
                return;

            ComboBoxItem selectedItem = TypeComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null)
                return;

            type = selectedItem.Content as string;
            if (type == null)
                return;

            fixedBooking.Items.Clear();
            flexibleBooking.Items.Clear();

            AddPromptDynamicComboBox(fixedBooking, "Choose your weeks");
            AddPromptDynamicComboBox(flexibleBooking, "Choose your hours");

            for (int i = 4; i <= 8; i++)
            {
                fixedBooking.Items.Add(new ComboBoxItem { Content = i.ToString() });
            }
            for (int i = 1; i <= 40; i++)
            {
                if (i % 5 == 0)
                {
                    flexibleBooking.Items.Add(i);
                }
            }

            if (type == "Fixed")
            {
                Dynamic.Text = "Total weeks:";
                DynamicInputControl.Content = fixedBooking;
            }
            else if (type == "Flexible")
            {
                Dynamic.Text = "Total hours:";
                DynamicInputControl.Content = flexibleBooking;
            }
            else
            {
                Dynamic.Text = string.Empty;
                DynamicInputControl.Content = null;
            }
            type = selectedItem.Content as string;
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

        private void AddPromptDynamicComboBox(ComboBox comboBox, string promptText)
        {
            ComboBoxItem promptItem = new ComboBoxItem
            {
                Content = promptText,
                IsEnabled = false,
                IsSelected = true
            };
            comboBox.Items.Add(promptItem);
        }

        private void InitializeTimeSlots()
        {
            TimeSlotComboBox.Items.Clear();
            AddPromptComboBox();

            List<string> timeSlots = new List<string>
            {
                "9:00 AM - 10:00 AM",
                "10:00 AM - 11:00 AM",
                "11:00 AM - 12:00 PM",
                "12:00 PM - 1:00 PM",
                "1:00 PM - 2:00 PM",
                "2:00 PM - 3:00 PM",
                "3:00 PM - 4:00 PM",
                "4:00 PM - 5:00 PM"
            };

            foreach (var slot in timeSlots)
            {
                ComboBoxItem item = new ComboBoxItem
                {
                    Content = slot
                };
                TimeSlotComboBox.Items.Add(item);
            }
        }

        private void BookingDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BookingDatePicker.SelectedDate.HasValue)
            {
                DateTime selectedDate = BookingDatePicker.SelectedDate.Value;

                if (selectedDate < DateTime.Today)
                {
                    MessageBox.Show("Please select a date that is today or later.");
                    BookingDatePicker.SelectedDate = DateTime.Today;
                }
                else
                {
                    DateOnly dateOnly = DateOnly.FromDateTime(selectedDate);
                    List<TimeSlot> slots = timeSlotObject.getByDate(dateOnly);

                    InitializeTimeSlots();

                    if (disabledTimeSlots.ContainsKey(dateOnly))
                    {
                        foreach (var timeSlot in disabledTimeSlots[dateOnly])
                        {
                            foreach (ComboBoxItem item in TimeSlotComboBox.Items)
                            {
                                if (item.Content.ToString() == timeSlot)
                                {
                                    item.IsEnabled = false;
                                }
                            }
                        }
                    }

                    foreach (var slot in slots)
                    {
                        for (int i = TimeSlotComboBox.Items.Count - 1; i >= 0; i--)
                        {
                            ComboBoxItem item = TimeSlotComboBox.Items[i] as ComboBoxItem;
                            if (item != null && item.Content.ToString() == slot.TsTime)
                            {
                                TimeSlotComboBox.Items.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            if (!BookingDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a booking date.");
                return;
            }

            if (TimeSlotComboBox.SelectedItem == null || (TimeSlotComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() == "Choose your time")
            {
                MessageBox.Show("Please select a valid time slot.");
                return;
            }

            DateOnly date = DateOnly.FromDateTime(BookingDatePicker.SelectedDate.Value);
            string timeSlot = (TimeSlotComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            string bookingDisplay = $"{date} - {timeSlot}";
            ComboBoxItem selectedItem = (ComboBoxItem)TimeSlotComboBox.SelectedItem;
            if (type == "Fixed")
            {
                if (fixedBooking.SelectedItem == null || (fixedBooking.SelectedItem as ComboBoxItem)?.Content.ToString() == "Choose your weeks")
                {
                    MessageBox.Show("Please select the number of weeks.");
                    return;
                }
                int weeks = int.Parse((fixedBooking.SelectedItem as ComboBoxItem).Content.ToString());
                bookingDisplay += $" ({weeks} weeks)";
            }
            else if (type == "Flexible")
            {
                if (flexibleBooking.SelectedItem == null || (flexibleBooking.SelectedItem as ComboBoxItem)?.Content.ToString() == "Choose your hours")
                {
                    MessageBox.Show("Please select the number of hours.");
                    return;
                }
                int hours = int.Parse((flexibleBooking.SelectedItem as ComboBoxItem).Content.ToString());
                bookingDisplay += $" ({hours - BookingsListBox.Items.Count - 1} hours)";
            }

            TimeSlot slot = new TimeSlot
            {
                CoId = Properties.Settings.Default.CourtId,
                TsCheckedIn = false,
                TsDate = date,
                TsTime = timeSlot
            };
            timeSlots.Add(slot);

            if (!disabledTimeSlots.ContainsKey(date))
            {
                disabledTimeSlots[date] = new List<string>();
            }
            disabledTimeSlots[date].Add(timeSlot);

            BookingsListBox.Items.Add(bookingDisplay);
            TimeSlotComboBox.SelectedIndex = 0;
            if (selectedItem != null)
            {
                selectedItem.IsEnabled = false;
            }
            if (BookingsListBox.Items.Count > 0)
            {
                TypeComboBox.IsEnabled = false;
            }
        }


        private void FixedBooking_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBookingDisplay();
        }

        private void FlexibleBooking_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBookingDisplay();
        }

        private void UpdateBookingDisplay()
        {
            int count = BookingsListBox.Items.Count;
            for (int i = 0; i < BookingsListBox.Items.Count; i++)
            {
                string originalDisplay = BookingsListBox.Items[i].ToString();
                string newDisplay = originalDisplay.Split('(')[0].Trim();

                if (type == "Fixed" && fixedBooking.SelectedItem != null)
                {
                    int weeks = int.Parse(fixedBooking.SelectedItem.ToString());
                    newDisplay += $" ({weeks} weeks)";
                }
                else if (type == "Flexible" && flexibleBooking.SelectedItem != null)
                {
                    int hours = int.Parse(flexibleBooking.SelectedItem.ToString());
                    newDisplay += $" ({hours - count - 1} hours)";
                }

                BookingsListBox.Items[i] = newDisplay;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            timeSlots.Clear();
            BookingsListBox.Items.Clear();
            BookingDatePicker.SelectedDate = DateTime.Today;
            TimeSlotComboBox.SelectedIndex = 0;
            TypeComboBox.IsEnabled = true;
            foreach (var item in TimeSlotComboBox.Items)
            {
                ComboBoxItem comboBoxItem = (ComboBoxItem)item;
                if (comboBoxItem != null)
                {
                    comboBoxItem.IsEnabled = true;
                }
            }
            disabledTimeSlots.Clear();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (BookingsListBox.Items.Count == 0)
            {
                MessageBox.Show("There are no bookings to confirm.");
                return;
            }

            if (MessageBox.Show("Are you certain with your decision?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int totalHours = 0;
                if (type == "Flexible")
                {
                    if (flexibleBooking.SelectedItem is ComboBoxItem flexibleItem && flexibleItem.Content != null)
                    {
                        totalHours = int.Parse(flexibleItem.Content.ToString()) - BookingsListBox.Items.Count;
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid number of hours.");
                        return;
                    }
                }
                else
                {
                    if (fixedBooking.SelectedItem is ComboBoxItem fixedItem && fixedItem.Content != null)
                    {
                        totalHours = int.Parse(fixedItem.Content.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Please select a valid number of weeks.");
                        return;
                    }
                }
                MessageBox.Show(Properties.Settings.Default.UserId.ToString());
                Booking booking = new Booking
                {
                    CoId = Properties.Settings.Default.CourtId,
                    BBookingType = type,
                    UserId = Properties.Settings.Default.UserId,
                    BTotalHours = totalHours
                };

                if (type == "Casual" || type == "Flexible")
                {
                    foreach (TimeSlot slot in timeSlots)
                    {
                        booking.TimeSlots.Add(slot);
                    }
                }
                else if (type == "Fixed")
                {
                    int weeks = totalHours;
                    foreach (var item in timeSlots)
                    {
                        for (int i = 0; i < weeks; i++)
                        {
                            TimeSlot timeSlot = new TimeSlot()
                            {
                                CoId = item.CoId,
                                TsCheckedIn = item.TsCheckedIn,
                                TsDate = item.TsDate.AddDays(7 * i),
                                TsTime = item.TsTime,
                            };
                            booking.TimeSlots.Add(timeSlot);
                        }
                    }
                }

                bookingObject.Insert(booking);
                MessageBox.Show("Booking confirmed!");
                WindowCourt court = new WindowCourt();
                this.Close();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
           WindowCourt court = new WindowCourt();
            court.Show();
            this.Close();
        }
    }
}
