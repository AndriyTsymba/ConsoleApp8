using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Journal
    {
        public int EmployeesCount { get; private set; }
        public Journal(int initialEmployees)
        {
            if (initialEmployees < 0)
                throw new ArgumentException("Кількість працівників не може бути від'ємною.");

            EmployeesCount = initialEmployees;
        }
        public static Journal operator +(Journal journal, int count)
        {
            if (count < 0)
                throw new ArgumentException("Число для додавання повинно бути невід'ємним.");

            return new Journal(journal.EmployeesCount + count);
        }
        public static Journal operator -(Journal journal, int count)
        {
            if (count < 0)
                throw new ArgumentException("Число для віднімання повинно бути невід'ємним.");

            if (journal.EmployeesCount - count < 0)
                throw new InvalidOperationException("Кількість працівників не може бути від'ємною.");

            return new Journal(journal.EmployeesCount - count);
        }
        public static bool operator ==(Journal journal1, Journal journal2)
        {
            if (ReferenceEquals(journal1, null) && ReferenceEquals(journal2, null))
                return true;

            if (ReferenceEquals(journal1, null) || ReferenceEquals(journal2, null))
                return false;

            return journal1.EmployeesCount == journal2.EmployeesCount;
        }
        public static bool operator !=(Journal journal1, Journal journal2)
        {
            return !(journal1 == journal2);
        }
        public static bool operator <(Journal journal1, Journal journal2)
        {
            if (ReferenceEquals(journal1, null) || ReferenceEquals(journal2, null))
                throw new ArgumentNullException("Обидва об'єкти мають бути непустими.");

            return journal1.EmployeesCount < journal2.EmployeesCount;
        }
        public static bool operator >(Journal journal1, Journal journal2)
        {
            if (ReferenceEquals(journal1, null) || ReferenceEquals(journal2, null))
                throw new ArgumentNullException("Обидва об'єкти мають бути непустими.");

            return journal1.EmployeesCount > journal2.EmployeesCount;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Journal otherJournal = (Journal)obj;
            return this.EmployeesCount == otherJournal.EmployeesCount;
        }
        public override int GetHashCode()
        {
            return EmployeesCount.GetHashCode();
        }
        public override string ToString()
        {
            return $"Кількість працівників: {EmployeesCount}";
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Journal journal1 = new Journal(10);
                Journal journal2 = new Journal(15);
                var journal3 = journal1 + 5;
                Console.WriteLine(journal3);
                var journal4 = journal2 - 3;
                Console.WriteLine(journal4); 
                Console.WriteLine(journal1 == journal2);
                Console.WriteLine(journal1 != journal2);
                Console.WriteLine(journal1 < journal2);
                Console.WriteLine(journal1 > journal2);
                Console.WriteLine(journal1.Equals(journal2));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}