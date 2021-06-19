using System;
using System.Threading.Tasks;
using AutoReact.Helpers;
using Microsoft.Test.Input;

namespace AutoReact
{
    public class ClickerService
    {
        public async Task Click(string clickSide, int x, int y, int clickCount, int speed)
        {
            Win32.SetCursorPos(x, y);
            await Task.Delay(TimeSpan.FromMilliseconds(50));
            Mouse.Click(MouseButton.Left);

        }
    }
}
