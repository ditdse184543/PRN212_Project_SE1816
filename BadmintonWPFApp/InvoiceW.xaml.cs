using BusinessObject;
using DataAccess;
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
    /// Interaction logic for InvoiceW.xaml
    /// </summary>
    public partial class InvoiceW : Window
    {
        public InvoiceW(InvoiceViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
