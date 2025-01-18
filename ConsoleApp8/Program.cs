using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Store
    {
        public double Area { get; private set; }
        public Store(double area)
        {
            if (area < 0)
                throw new ArgumentException("Площа магазину не може бути від'ємною.");

            Area = area;
        }
        public static Store operator +(Store store, double size)
        {
            if (size < 0)
                throw new ArgumentException("Розмір для збільшення площі не може бути від'ємним.");

            return new Store(store.Area + size);
        }
        public static Store operator -(Store store, double size)
        {
            if (size < 0)
                throw new ArgumentException("Розмір для зменшення площі не може бути від'ємним.");

            if (store.Area - size < 0)
                throw new InvalidOperationException("Площа магазину не може бути від'ємною.");

            return new Store(store.Area - size);
        }
        public static bool operator ==(Store store1, Store store2)
        {
            if (ReferenceEquals(store1, null) && ReferenceEquals(store2, null))
                return true;

            if (ReferenceEquals(store1, null) || ReferenceEquals(store2, null))
                return false;

            return store1.Area == store2.Area;
        }
        public static bool operator !=(Store store1, Store store2)
        {
            return !(store1 == store2);
        }
        public static bool operator <(Store store1, Store store2)
        {
            if (ReferenceEquals(store1, null) || ReferenceEquals(store2, null))
                throw new ArgumentNullException("Обидва об'єкти мають бути непустими.");

            return store1.Area < store2.Area;
        }
        public static bool operator >(Store store1, Store store2)
        {
            if (ReferenceEquals(store1, null) || ReferenceEquals(store2, null))
                throw new ArgumentNullException("Обидва об'єкти мають бути непустими.");

            return store1.Area > store2.Area;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Store otherStore = (Store)obj;
            return this.Area == otherStore.Area;
        }
        public override int GetHashCode()
        {
            return Area.GetHashCode();
        }
        public override string ToString()
        {
            return $"Площа магазину: {Area} кв.м.";
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Store store1 = new Store(100); 
                Store store2 = new Store(150);  
                var store3 = store1 + 20;
                Console.WriteLine(store3); 
                var store4 = store2 - 30;
                Console.WriteLine(store4); 
                Console.WriteLine(store1 == store2);
                Console.WriteLine(store1 != store2);

                Console.WriteLine(store1 < store2); 
                Console.WriteLine(store1 > store2); 
                Console.WriteLine(store1.Equals(store2));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}