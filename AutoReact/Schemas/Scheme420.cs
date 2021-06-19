using System.Collections.Generic;
using AutoReact.Interfaces.Schemas;

namespace AutoReact.Schemas
{
    public class Scheme420 : ISchema
    {
        public List<List<bool>> GetFirstPart()
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

        public List<List<bool>> GetSecondPart()
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

        public List<List<bool>> GetLittle()
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
        public List<List<bool>> GetSkin()
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
