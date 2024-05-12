using System;
using System.Collections.Generic;

namespace Lab10
{
    partial class FoodQualityAnalyzer : IStatistic
    {
        public int Max()
        {
            int ma = int.MinValue;
            foreach (var product in _products)
            {
                if (product.GetQuality() > ma)
                {
                    ma = product.GetQuality();
                }
            }
            return ma;
        }
        public int Min()
        {
            int mi = int.MaxValue;
            foreach (var product in _products)
            {
                if (product.GetQuality() < mi)
                {
                    mi = product.GetQuality();
                }
            }
            return mi;
        }
        public decimal Avg()
        {
            decimal sum = 0;
            foreach (var product in _products)
            {
                sum += product.GetQuality();
            }
            return sum/_products.Length;
        }
        public int Med()
        {
            return 0;
        }
        public string[] GetStat()
        {
            return new String[4] { $"Максимальное значение: {Max()}", $"Минимальное значение: {Min()}", $"Среднее значение: {Avg()}", $"Медианное значение: {Med()}" };
        }
    }
}
