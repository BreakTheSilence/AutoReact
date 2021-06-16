using System;
using System.Windows;
using System.Windows.Media;
using AutoReact.Entities;
using AutoReact.Events;
using AutoReact.Helpers;
using AutoReact.Services;

namespace AutoReact
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalibrationObject _calibrationObject;
        private LayoutService _layoutService;
        private RegistryService _registryService;

        public MainWindow()
        {
            InitializeComponent();
            _registryService = new RegistryService();
            RetrieveCalibrationSettingsFromRegistry();
        }


        private async void CalibrateButtonClick(object sender, RoutedEventArgs e)
        {
            TipTextBlock.Visibility = Visibility.Visible;
            var calibrationService = new CalibrationService();
            calibrationService.CalibrationEvent += CalibrationServiceEvent;
            _calibrationObject = await calibrationService.Calibrate();
            var jsonString = JsonConverter.ConvertToJson(_calibrationObject);
            if (!string.IsNullOrEmpty(jsonString))
            {
                _registryService.WriteToRegistry("UserSettings", jsonString);
            }
            MainBorder.BorderBrush = Brushes.LimeGreen;
            _layoutService = new LayoutService(_calibrationObject);
            TipTextBlock.Visibility = Visibility.Collapsed;
        }

        private void CalibrationServiceEvent(object? sender, EventArgs e)
        {
            if (!(e is CalibrationEventArgs args)) return;
            TipTextBlock.Text = args.Message;
        }

        private async void SetReactor_420(object sender, RoutedEventArgs e)
        {
            if (_layoutService == null) return;
            await _layoutService.SetReactor_420_Main();
        }

        private async void SetReactor_420_Left(object sender, RoutedEventArgs e)
        {
            if (_layoutService == null) return;
            await _layoutService.SetReactor_420_Left();
        }

        private void RetrieveCalibrationSettingsFromRegistry()
        {
            var jsonString = _registryService.ReadFromRegistry("UserSettings");
            if (jsonString == null)
            {
                MainBorder.BorderBrush = Brushes.Red;
                return;
            }
            var settings = JsonConverter.ConvertFromJson(jsonString, new CalibrationObject());
            if (settings is CalibrationObject obj)
            {
                _calibrationObject = obj;
                MainBorder.BorderBrush = Brushes.LimeGreen;
                _layoutService = new LayoutService(_calibrationObject);
            }
            else
            {
                MainBorder.BorderBrush = Brushes.Red;
            }
        }
    }
}
