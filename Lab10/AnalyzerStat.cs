using System;
using System.Collections.Generic;
using System.Linq;

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
        public double Avg()
        {
            double sum = 0;
            foreach (var product in _products)
            {
                sum += product.GetQuality();
            }
            return sum/_products.Length;
        }
        public double Med()
        {
            FoodProduct[] _sorted = _products.ToArray();
            FoodProduct temp;
            for (int i = 0; i < _sorted.Length; i++)
            {
                for (int j = i + 1; j < _sorted.Length; j++)
                {
                    if (_sorted[i].GetQuality() > _sorted[j].GetQuality())
                    {
                        temp = _sorted[i];
                        _sorted[i] = _sorted[j];
                        _sorted[j] = temp;
                    }
                }
            }
            if (_sorted.Length % 2 != 0)
            {
                return _sorted[_sorted.Length / 2].GetQuality();
            }
            else
            {
                return (_sorted[_sorted.Length / 2].GetQuality() + _sorted[_sorted.Length / 2 - 1].GetQuality()) / 2.0;
            }
        }
        public string[] GetStat()
        {
            return new String[4] { $"Максимальное значение: {Max()}", $"Минимальное значение: {Min()}", $"Среднее значение: {Avg()}", $"Медианное значение: {Med()}" };
        }
    }
}
