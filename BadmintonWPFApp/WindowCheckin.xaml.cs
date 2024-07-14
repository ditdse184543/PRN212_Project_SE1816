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
    /// Interaction logic for WindowCheckin.xaml
    /// </summary>
    public partial class WindowCheckin : Window
    {

        //private readonly AirConditionerObjects airConditionerObjects;
        //public WindowCheckin()
        //{
        //    InitializeComponent();
        //    Loaded += AC_Loaded;
        //    airConditionerObjects = new AirConditionerObjects();
        //}

        //private void AC_Loaded(object sender, RoutedEventArgs e)
        //{
        //    LoadACList();
        //}

        //private void LoadACList()
        //{
        //    try
        //    {
        //        var acList = airConditionerObjects.GetAirConditioners().Select(x => new
        //        {
        //            AirConditionerId = x.AirConditionerId,
        //            AirConditionerName = x.AirConditionerName,
        //            Warranty = x.Warranty,
        //            SoundPressureLevel = x.SoundPressureLevel,
        //            FeatureFunction = x.FeatureFunction,
        //            Quantity = x.Quantity,
        //            DollarPrice = x.DollarPrice,
        //            SupplierName = x.Supplier.SupplierName
        //        }).ToList();
        //        ACDataGrid.ItemsSource = acList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //private void AddACButton_Click(object sender, RoutedEventArgs e)
        //{
        //    WAddACPopUp wAddACPopUp = new WAddACPopUp();
        //    wAddACPopUp.ShowDialog();
        //    LoadACList();
        //}

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

        //private void ReloadACButton_Click(object sender, RoutedEventArgs e)
        //{

        //    LoadACList();
        //}
    }
}
