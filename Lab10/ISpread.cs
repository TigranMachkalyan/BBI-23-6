using System;
using System.Collections.Generic;

namespace Lab10
{
    interface ISpreadable
    {
        void Add(FoodProduct foodProduct);
        void Add(FoodProduct foodProduct, int quantity);
        void Delete(FoodProduct foodProduct);
        void Delete(FoodProduct foodProduct, int quantity);
    }
}
