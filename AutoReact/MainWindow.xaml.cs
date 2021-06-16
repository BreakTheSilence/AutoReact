using System;
using System.Windows;
using AutoReact.Entities;
using AutoReact.Events;
using AutoReact.Services;

namespace AutoReact
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalibrationObject _calibrationObject;

        public MainWindow()
        {
            InitializeComponent();
        }


        private async void CalibrateButtonClick(object sender, RoutedEventArgs e)
        {
            TipTextBlock.Visibility = Visibility.Visible;
            var calibrationService = new CalibrationService();
            calibrationService.CalibrationEvent += CalibrationServiceEvent;
            _calibrationObject = await calibrationService.Calibrate();
            TipTextBlock.Visibility = Visibility.Collapsed;
        }

        private void CalibrationServiceEvent(object? sender, EventArgs e)
        {
            if (!(e is CalibrationEventArgs args)) return;
            TipTextBlock.Text = args.Message;
        }

        private async void SetReactor_420(object sender, RoutedEventArgs e)
        {
            var layoutService = new LayoutService(_calibrationObject);
            await layoutService.SetReactor_420();
        }
    }
}
