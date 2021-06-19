using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using AutoReact.Entities;
using AutoReact.Interfaces.Schemas;
using AutoReact.Schemas;

namespace AutoReact.Services
{
    public class LayoutService
    {
        private CalibrationObject _calibrationObject;
        private ClickerService _clickerService;
        private Point _currentInventorySlot;
        private readonly ISchema _schema;
        public LayoutService(CalibrationObject calibrationObject, ISchema schema)
        {
            _schema = schema;
            _clickerService = new ClickerService();
            _calibrationObject = calibrationObject;
        }

        public async Task ReactorSetFirstPart()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            _currentInventorySlot = new Point(0, 0);
            await SetCoolers(_schema.GetFirstPart());
        }

        public async Task ReactorSetSecondPart()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            _currentInventorySlot = new Point(0, 0);
            var secondPart = _schema.GetSecondPart();
            var littlePart = _schema.GetLittle();
            var skin = _schema.GetSkin();
            if (secondPart != null)
            {
                await SetCoolers(secondPart);
            }
            if (littlePart != null)
            {
                await SetCoolers(littlePart);
            }

            if (skin != null)
            {
                await SetSkin(skin);
            }
        }

        private async Task SetCoolers(IReadOnlyList<List<bool>> schema)
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

                        await _clickerService.Click("LEFT", invXPoint, invYPoint, 1, 1);

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

                        await _clickerService.Click("LEFT", reactXPoint, reactYPoint, 1, 1);
                    }
                }
            }
        }

        private async Task SetSkin(IReadOnlyList<List<bool>> schema)
        {
            var invXPoint = (int)(_calibrationObject.InventoryStartPoint.X + _currentInventorySlot.X * _calibrationObject.CellSize);
            var invYPoint = (int)(_calibrationObject.InventoryStartPoint.Y + _currentInventorySlot.Y * _calibrationObject.CellSize);
            await _clickerService.Click("LEFT", invXPoint, invYPoint, 1, 1);
            for (var y = 0; y < schema.Count; y++)
            {
                var innerList = schema[y];
                for (var x = 0; x < innerList.Count; x++)
                {
                    if (!innerList[x]) continue;
                    var reactXPoint = (int)(_calibrationObject.ReactorStartPoint.X + x * _calibrationObject.CellSize);
                    var reactYPoint = (int)(_calibrationObject.ReactorStartPoint.Y + y * _calibrationObject.CellSize);

                    await _clickerService.Click("RIGHT", reactXPoint, reactYPoint, 1, 1);
                }
            }
        }
    }
}
