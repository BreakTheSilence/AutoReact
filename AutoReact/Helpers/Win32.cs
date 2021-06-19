using System.Runtime.InteropServices;

namespace AutoReact.Helpers
{
    public static class Win32
    {
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
    }
}
