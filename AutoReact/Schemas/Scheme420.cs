using System.Collections.Generic;

namespace AutoReact.Schemas
{
    public static class Scheme420
    {
        public static List<List<bool>> Main => GetMain();
        public static List<List<bool>> Cool => GetCool();
        public static List<List<bool>> Little => GetLittle();
        public static List<List<bool>> Skin => GetSkin();

        private static List<List<bool>> GetMain()
        {
            var sch = new List<List<bool>>()
            {
                new List<bool>() {false, false, true, false, true, true, false, true, false},
                new List<bool>() {false, false, true, true, false, true, true, false, true},
                new List<bool>() {false, true, false, true, true, false, true, true, false},
                new List<bool>() {false, true, true, false, true, true, false, true, false},
                new List<bool>() {true, false, true, true, false, true, true, false, true},
                new List<bool>() {false, true, false, false, true, false, false, true, false}
            };
            return sch;
        }

        private static List<List<bool>> GetCool()
        {
            var sch = new List<List<bool>>()
            {
                new List<bool>() {false, true, false, false, false, false, true, false, false},
                new List<bool>() {false, true, false, false, true, false, false, false, false},
                new List<bool>() {false, false, false, false, false, false, false, false, true},
                new List<bool>() {true, false, false, true, false, false, true, false, false},
                new List<bool>() {false, false, false, false, false, false, false, false, false},
                new List<bool>() {false, false, true, false, false, true, false, false, true},
            };
            return sch;
        }

        private static List<List<bool>> GetLittle()
        {
            var sch = new List<List<bool>>()
            {
                new List<bool>() {false, false, false, true, false, false, false, false, false},
                new List<bool>() {false, false, false, false, false, false, false, false, false},
                new List<bool>() {false, false, false, false, false, false, false, false, false},
                new List<bool>() {false, false, false, false, false, false, false, false, false},
                new List<bool>() {false, false, false, false, false, false, false, false, false},
                new List<bool>() {false, false, false, false, false, false, false, false, false},
            };
            return sch;
        }
        private static List<List<bool>> GetSkin()
        {
            var sch = new List<List<bool>>()
            {
                new List<bool>() {false, false, false, false, false, false, false, false, true},
                new List<bool>() {true, false, false, false, false, false, false, false, false},
                new List<bool>() {true, false, false, false, false, false, false, false, false},
                new List<bool>() {false, false, false, false, false, false, false, false, true},
                new List<bool>() {false, false, false, false, false, false, false, false, false},
                new List<bool>() {true, false, false, true, false, false, true, false, false},
            };
            return sch;
        }
    }
}
