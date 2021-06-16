using System.Windows;

namespace AutoReact.Entities
{
    public class CalibrationObject
    {
        public Point InventoryStartPoint { get; set; }
        public Point ReactorStartPoint { get; set; }
        public double CellSize { get; set; }
    }
}
