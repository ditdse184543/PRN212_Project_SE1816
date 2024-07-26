using BusinessObject;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }
    }
}
