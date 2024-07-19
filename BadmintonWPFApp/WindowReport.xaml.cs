using BusinessObject;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for WindowReport.xaml
    /// </summary>
    public partial class WindowReport : Window
    {
        private int courtID;
        private readonly CourtConditionObject cco;
        public WindowReport(int cId)
        {
            InitializeComponent();
            courtID = cId;
            this.cco = new CourtConditionObject();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int surfaceCondition = GetSelectedRadioButtonValue("SurfaceCondition");
            int lightingCondition = GetSelectedRadioButtonValue("LightingCondition");
            int netCondition = GetSelectedRadioButtonValue("NetCondition");
            int cleanlinessCondition = GetSelectedRadioButtonValue("CleanlinessCondition");
            string notes = notesTextBox.Text;

            // Ensure all conditions are selected
            if (surfaceCondition == 0 || lightingCondition == 0 || netCondition == 0 || cleanlinessCondition == 0)
            {
                MessageBox.Show("Please select a value for all conditions.");
                return;
            }

            int overallCondition = (surfaceCondition + lightingCondition + netCondition + cleanlinessCondition) / 4;

            CourtCondition courtCondition = new CourtCondition
            {
                CdCleanlinessCondition = cleanlinessCondition,
                CdLightningCondition = lightingCondition,
                CdNetCondition = netCondition,
                CdSurfaceCondition = surfaceCondition,
                CdOverallCondition = overallCondition,
                CoId = courtID,
                CdCreatedAt = DateTime.Now,
                CdNotes = string.IsNullOrWhiteSpace(notes) ? null : notes
            };

            

            MessageBox.Show("Court quality check submitted successfully!");
            cco.Insert(courtCondition);
            CourtReportListQualityW courtReportListQualityW = new CourtReportListQualityW();
            courtReportListQualityW.Show();
            this.Close();
        }

        private int GetSelectedRadioButtonValue(string groupName)
        {
            var radioButtons = FindName(groupName) as StackPanel;
            if (radioButtons == null)
                throw new Exception($"RadioButton group {groupName} not found.");

            var selectedRadioButton = radioButtons.Children.OfType<RadioButton>()
                                                  .FirstOrDefault(rb => rb.IsChecked == true);

            if (selectedRadioButton == null)
                return 0; 

            return int.Parse(selectedRadioButton.Tag.ToString());
        }
    }
}

