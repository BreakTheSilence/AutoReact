using System.Threading.Tasks;
using AutoReact.Entities;

namespace AutoReact.Services
{
    public class LayoutService
    {
        private CalibrationObject _calibrationObject;
        public LayoutService(CalibrationObject calibrationObject)
        {
            _calibrationObject = calibrationObject;
        }

        public async Task SetReactor_420()
        {

        }

        // private void ClickToLastPointButton(object sender, RoutedEventArgs e)
        // {
        //     autoit.Click("LEFT", _point.X, _point.Y, 1, 1);
        // }
    }
}
