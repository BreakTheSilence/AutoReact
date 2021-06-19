using System;
using System.Windows;
using System.Windows.Media;
using AutoReact.Entities;
using AutoReact.Events;
using AutoReact.Helpers;
using AutoReact.Schemas;
using AutoReact.Services;
using AutoReact.Views;

namespace AutoReact
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalibrationObject _calibrationObject;
        private readonly CalibrationService _calibrationService;

        public MainWindow()
        {
            InitializeComponent();
            _calibrationService = new CalibrationService();
            RetrieveCalibrationSettingsFromRegistry();
        }

        private void RetrieveCalibrationSettingsFromRegistry()
        {
            var jsonString = RegistryService.ReadFromRegistry("UserSettings");
            if (jsonString == null)
            {
                CalibrationStateRec.Fill = Brushes.Red;
                return;
            }
            var settings = JsonConverter.ConvertFromJson(jsonString, new CalibrationObject());
            if (settings is CalibrationObject obj)
            {
                _calibrationObject = obj;
                CalibrationStateRec.Fill = Brushes.LimeGreen;
            }
            else
            {
                CalibrationStateRec.Fill = Brushes.Red;
            }
        }

        private void NavigateToCalibrationView(object sender, RoutedEventArgs e)
        {
            var calibrationView = new CalibrationView();
            calibrationView.InitializePage(_calibrationService);

            calibrationView.CalibrationCompleted += delegate(object? o, EventArgs args)
            {
                if (!(args is CalibrationCompletedEventArgs e)) return;
                _calibrationObject = e.CalibrationObject;
                CalibrationStateRec.Fill = Brushes.GreenYellow;
            };

            ContentFrame.NavigationService.Navigate(calibrationView, _calibrationService);
        }

        private void NavigateToReactorLayoutView(object sender, RoutedEventArgs e)
        {
            if (_calibrationObject == null) return;
            var layoutService = new LayoutService(_calibrationObject, new Scheme420());
            var reactorLayoutView = new ReactorLayoutView();
            reactorLayoutView.InitializePage(layoutService);

            ContentFrame.NavigationService.Navigate(reactorLayoutView, layoutService);
        }
    }
}
