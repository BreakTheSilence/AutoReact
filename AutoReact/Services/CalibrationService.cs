using System;
using System.Threading.Tasks;
using System.Windows;
using AutoReact.Entities;
using AutoReact.Events;
using AutoReact.Helpers;
using Gma.System.MouseKeyHook;

namespace AutoReact.Services
{
    public class CalibrationService
    {
        public event EventHandler CalibrationEvent;

        private IKeyboardMouseEvents _globalHook;
        private TaskCompletionSource<object> _mouseClicked;
        private Point _clickedPoint;

        public CalibrationService()
        {
            _globalHook = Hook.GlobalEvents();
        }

        public async Task<CalibrationObject> Calibrate()
        {
            CalibrationEvent?.Invoke(this, 
                new CalibrationEventArgs("Нажми в центр левой верхней клетки в инвентаре"));
            var inventoryStartPoint = await GetClickPoint();

            CalibrationEvent?.Invoke(this,
                new CalibrationEventArgs("Нажми в центр левой верхней клетки в реакторе"));
            var reactorStartPoint = await GetClickPoint();

            var cellSize = await GetCellSize(reactorStartPoint);

            var calibrationObject = new CalibrationObject()
            {
                InventoryStartPoint = inventoryStartPoint,
                ReactorStartPoint = reactorStartPoint,
                CellSize = cellSize
            };
            return calibrationObject;
        }

        private async Task<Point> GetClickPoint()
        {
            _globalHook.MouseDownExt += MouseClickEvent;
            _mouseClicked = new TaskCompletionSource<object>();
            await _mouseClicked.Task;
            _mouseClicked = null;
            _globalHook.MouseDownExt -= MouseClickEvent;
            return _clickedPoint;
        }

        private async Task<double> GetCellSize(Point reactorFirstPoint)
        {
            CalibrationEvent?.Invoke(this,
                new CalibrationEventArgs("Нажми в центр клетки, которая справа от предыдущей"));
            var end = await GetClickPoint();

            return end.X - reactorFirstPoint.X;
        }

        private void MouseClickEvent(object? sender, MouseEventExtArgs e)
        {
            var point = GetMousePosition();
            _clickedPoint = new Point(point.X, point.Y);
            _mouseClicked?.TrySetResult(null);
        }

        private POINT GetMousePosition()
        {
            POINT point;
            Win32.GetCursorPos(out point);
            return point;
        }
    }
}
