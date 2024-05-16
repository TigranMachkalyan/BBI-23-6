using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lab10
{
    struct Standart
    {
        private string _name;
        private double[] _values;
        public Standart(string name, double[] values)
        {
            _name = name;
            _values = values;
        }
        public double Value(int index)
        {
            return _values[index];
        }
    }
}
