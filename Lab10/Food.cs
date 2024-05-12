using System;
using System.Collections.Generic;

namespace Lab10
{
    abstract class FoodProduct
    {
        protected string _name;
        protected int _weight;
        protected DateTime _expiryDate;
        public FoodProduct(string name, int weight, string date)
        {
            _name = name;
            _weight = weight;
            string[] d = date.Split('.');
            _expiryDate = new DateTime(int.Parse(d[2]), int.Parse(d[1]), int.Parse(d[0]));
        }
        public abstract int GetQuality();
        protected static int DaysToShelf(DateTime exp)
        {
            DateTime now = DateTime.Today;
            string dif = exp.Subtract(now).ToString();
            if (!dif.Contains("."))
            {
                return 0;
            }
            else
            {
                int d = int.Parse(dif.Split('.')[0]);
                return d;
            }
        }
        public override string ToString()
        {
            return $"Название: {_name}\nМасса: {_weight} г\nСрок годности истекает: {_expiryDate.ToString("dd.MM.yyyy")}";
        }
        public static bool operator == (FoodProduct a, FoodProduct b)
        {
            if (a._name == b._name && a._weight == b._weight && a._expiryDate == b._expiryDate) {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(FoodProduct a, FoodProduct b)
        {
            return !(a == b);
        }
    }
    class Vegetable : FoodProduct
    {
        private bool _frozen;
        private bool _packed;
        public Vegetable(string name, int weight, string date, bool frozen, bool packed) : base(name, weight, date)
        {
            _frozen = frozen;
            _packed = packed;
        }
        public override int GetQuality()
        {
            int res;
            int days = FoodProduct.DaysToShelf(_expiryDate);
            if (days >= 20) { res = 10; }
            else if (days < 0) {  res = 0; }
            else { res = days/2 + 1; }
            return res;
        }
        public override string ToString()
        {
            string f, p;
            if (_frozen) { f = "Да"; }
            else { f = "Нет"; }
            if (_packed) { p = "Да"; }
            else { p = "Нет"; }
            return $"Название: {_name}\nМасса: {_weight} г\nЗаморожен: {f}\nЗапакован: {p}\nСрок годности истекает: {_expiryDate.ToString("dd.MM.yyyy")}";
        }
    }
    class Fruit : FoodProduct
    {
        private string _country;
        private bool _packed;
        public Fruit(string name, int weight, string date, string country, bool packed) : base(name, weight, date)
        {
            _country = country;
            _packed = packed;
        }
        public override int GetQuality()
        {
            int res;
            int days = FoodProduct.DaysToShelf(_expiryDate);
            if (days >= 10) { res = 10; }
            else if (days < 0) { res = 0; }
            else { res = days; }
            return res;
        }
        public override string ToString()
        {
            string p;
            if (_packed) { p = "Да"; }
            else { p = "Нет"; }
            return $"Название: {_name}\nМасса: {_weight} г\nСтрана: {_country}\nЗапакован: {p}\nСрок годности истекает: {_expiryDate.ToString("dd.MM.yyyy")}";
        }
    }
    class Meat : FoodProduct
    {
        private bool _sliced;
        private bool _halal;
        public Meat(string name, int weight, string date, bool sliced, bool halal) : base(name, weight, date)
        {
            _sliced = sliced;
            _halal = halal;
        }
        public override int GetQuality()
        {
            int res;
            int days = FoodProduct.DaysToShelf(_expiryDate);
            if (days >= 15) { res = 10; }
            else if (days < 0) { res = 0; }
            else { res = (int)Math.Round(days/1.5); }
            return res;
        }
        public override string ToString()
        {
            string s, h;
            if (_sliced) { s = "Да"; }
            else { s = "Нет"; }
            if (_halal) { h = "Да"; }
            else { h = "Нет"; }
            return $"Название: {_name}\nМасса: {_weight} г\nНарезанное: {s}\nХаляль: {h}\nСрок годности истекает: {_expiryDate.ToString("dd.MM.yyyy")}";
        }
    }
    class Bakery : FoodProduct
    {
        private string _section;
        private bool _packed;
        public Bakery(string name, int weight, string date, string section, bool packed) : base(name, weight, date)
        {
            _section = section;
            _packed = packed;
        }
        public override int GetQuality()
        {
            int res;
            int days = FoodProduct.DaysToShelf(_expiryDate);
            if (days > 3) { res = 10; }
            else if (days < 0) { res = 0; }
            else { res = (int)Math.Round(days * 3.3); }
            return res;
        }
        public override string ToString()
        {
            string p;
            if (_packed) { p = "Да"; }
            else { p = "Нет"; }
            return $"Название: {_name}\nМасса: {_weight} г\nОтдел: {_section}\nЗапаковано: {p}\nСрок годности истекает: {_expiryDate.ToString("dd.MM.yyyy")}";
        }
    }
}