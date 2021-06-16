using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using AutoReact.Entities;
using AutoReact.Schemas;

namespace AutoReact.Services
{
    public class LayoutService
    {
        private CalibrationObject _calibrationObject;
        private Autoit _autoit;
        private Point _currentInventorySlot;
        public LayoutService(CalibrationObject calibrationObject)
        {
            _autoit = new Autoit();
            _calibrationObject = calibrationObject;
        }

        public async Task SetReactor_420_Main()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            _currentInventorySlot = new Point(0, 0);
            SetCoolers(Scheme420.Main);
        }

        public async Task SetReactor_420_Left()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            _currentInventorySlot = new Point(0, 0);
            SetCoolers(Scheme420.Cool);
            SetCoolers(Scheme420.Little);
            SetSkin(Scheme420.Skin);
        }

        private void SetCoolers(IReadOnlyList<List<bool>> schema)
        {
            for (var y = 0; y < schema.Count; y++)
            {
                var innerList = schema[y];
                for (var x = 0; x < innerList.Count; x++)
                {
                    if (innerList[x])
                    {
                        var invXPoint = (int)(_calibrationObject.InventoryStartPoint.X + _currentInventorySlot.X * _calibrationObject.CellSize);
                        var invYPoint = (int)(_calibrationObject.InventoryStartPoint.Y + _currentInventorySlot.Y * _calibrationObject.CellSize);

                        _autoit.Click("LEFT", invXPoint, invYPoint, 1, 1);

                        if (_currentInventorySlot.X < 8)
                        {
                            _currentInventorySlot.X += 1;
                        }
                        else
                        {
                            _currentInventorySlot.X = 0;
                            _currentInventorySlot.Y += 1;
                        }

                        var reactXPoint = (int)(_calibrationObject.ReactorStartPoint.X + x * _calibrationObject.CellSize);
                        var reactYPoint = (int)(_calibrationObject.ReactorStartPoint.Y + y * _calibrationObject.CellSize);

                        _autoit.Click("LEFT", reactXPoint, reactYPoint, 1, 1);
                    }
                }
            }
        }

        private void SetSkin(IReadOnlyList<List<bool>> schema)
        {
            var invXPoint = (int)(_calibrationObject.InventoryStartPoint.X + _currentInventorySlot.X * _calibrationObject.CellSize);
            var invYPoint = (int)(_calibrationObject.InventoryStartPoint.Y + _currentInventorySlot.Y * _calibrationObject.CellSize);
            _autoit.Click("LEFT", invXPoint, invYPoint, 1, 1);
            for (var y = 0; y < schema.Count; y++)
            {
                var innerList = schema[y];
                for (var x = 0; x < innerList.Count; x++)
                {
                    if (!innerList[x]) continue;
                    var reactXPoint = (int)(_calibrationObject.ReactorStartPoint.X + x * _calibrationObject.CellSize);
                    var reactYPoint = (int)(_calibrationObject.ReactorStartPoint.Y + y * _calibrationObject.CellSize);

                    _autoit.Click("RIGHT", reactXPoint, reactYPoint, 1, 1);
                }
            }
        }

        // private void ClickToLastPointButton(object sender, RoutedEventArgs e)
        // {
        //     autoit.Click("LEFT", _point.X, _point.Y, 1, 1);
        // }
    }
}
