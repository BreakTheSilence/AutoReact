using System;
using AutoReact.Entities;

namespace AutoReact.Events
{
    class CalibrationCompletedEventArgs : EventArgs
    {
        public CalibrationObject CalibrationObject { get; set; }        
    }
}
