using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab10
{
    partial class FoodQualityAnalyzer : ISpreadable
    {
        public void Add(FoodProduct foodProduct)
        {
            _products = _products.Append(foodProduct).ToArray();
        }

        public void Add(FoodProduct foodProduct, int quantity)
        {
            for(int i = 0; i < quantity; i++)
            {
                _products = _products.Append(foodProduct).ToArray();
            }
        }

        public void Delete(FoodProduct foodProduct)
        {
            FoodProduct[] products_temp = { };
            bool deleted = false;
            foreach (var product in _products)
            {
                if (product != foodProduct)
                {
                    products_temp = products_temp.Append(product).ToArray();
                }
                else if (deleted == true)
                {
                    products_temp = products_temp.Append(product).ToArray();
                }
                else { deleted = true; }
            }
            _products = products_temp;
        }

        public void Delete(FoodProduct foodProduct, int quantity)
        {
            FoodProduct[] products_temp = { };
            foreach (var product in _products)
            {
                if (product != foodProduct)
                {
                    products_temp = products_temp.Append(product).ToArray();
                }
                else if (quantity == 0)
                {
                    products_temp = products_temp.Append(product).ToArray();
                }
                else { quantity--; }
            }
            _products = products_temp;
        }
    }
}
