using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using AutoReact.Events;
using AutoReact.Helpers;
using AutoReact.Services;

namespace AutoReact.Views
{
    /// <summary>
    /// Interaction logic for CalibrationView.xaml
    /// </summary>
    public partial class CalibrationView : Page
    {
        public event EventHandler CalibrationCompleted;
        private CalibrationService _calibrationService;
        public CalibrationView()
        {
            InitializeComponent();
        }

        public void InitializePage(CalibrationService calibrationService)
        {
            _calibrationService = calibrationService;
        }


        private async void StartCalibrationButton(object sender, RoutedEventArgs e)
        {
            TipTextBlock.Visibility = Visibility.Visible;
            _calibrationService.CalibrationEvent += CalibrationServiceEvent;
            try
            {
                var calibrationObject = await _calibrationService.Calibrate();
                var jsonString = JsonConverter.ConvertToJson(calibrationObject);
                if (string.IsNullOrEmpty(jsonString))
                {
                    throw new Exception("Calibration failed");
                }
                RegistryService.WriteToRegistry("UserSettings", jsonString);
                TipTextBlock.Text = "Calibration Completed";
                CalibrationCompleted?.Invoke(this, new CalibrationCompletedEventArgs() { CalibrationObject = calibrationObject });
            }
            catch (Exception)
            {
                TipTextBlock.Text = "Calibration failed";
            }
        }

        private void CalibrationServiceEvent(object? sender, EventArgs e)
        {
            if (!(e is CalibrationEventArgs args)) return;
            TipTextBlock.Text = args.Message;
        }
    }
}
