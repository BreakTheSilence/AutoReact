using AutoItX3Lib;

namespace AutoReact
{
    public class Autoit
    {
        private readonly AutoItX3 _auto;
        public Autoit()
        {
            _auto = new AutoItX3();
        }
        

        public void Click(string clickSide, int x, int y, int clickCount, int speed)
        {
            _auto.MouseClick(clickSide, x, y, clickCount, speed);
        }
    }
}
