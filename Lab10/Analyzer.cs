using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab10
{
    partial class FoodQualityAnalyzer
    {
        private FoodProduct[] _products = { };
        public FoodProduct[] Products { get { return _products; } }
        public FoodQualityAnalyzer() { }
        public FoodQualityAnalyzer(FoodProduct[] products)
        {
            _products = products;
        }
        public IEnumerator GetEnumerator() => _products.GetEnumerator();
    }
}
