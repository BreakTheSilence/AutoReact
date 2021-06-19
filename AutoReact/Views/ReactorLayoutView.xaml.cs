using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using AutoReact.Services;

namespace AutoReact.Views
{
    /// <summary>
    /// Interaction logic for ReactorLayoutView.xaml
    /// </summary>
    public partial class ReactorLayoutView : Page
    {
        private LayoutService _layoutService;
        public ReactorLayoutView()
        {
            InitializeComponent();
        }

        public void InitializePage(LayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        private async void ReactorSetFirstPartButton(object sender, RoutedEventArgs e)
        {
            await _layoutService.ReactorSetFirstPart();
        }

        private async void ReactorSetSecondPartButton(object sender, RoutedEventArgs e)
        {
            await _layoutService.ReactorSetSecondPart();
        }
    }
}
