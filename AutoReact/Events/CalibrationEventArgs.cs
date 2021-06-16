using System;

namespace AutoReact.Events
{
    public class CalibrationEventArgs : EventArgs
    {
        public CalibrationEventArgs(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
