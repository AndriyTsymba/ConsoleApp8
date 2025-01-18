using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Library library = new Library(5);

            Console.WriteLine("Add books to the library:");
            library.Add("Book 1");
            library.Add("Book 2");
            Console.WriteLine("Books in the library:");
            for (int i = 0; i < library.Count; i++)
            {
                Console.WriteLine(library[i]);
            }
            library.Remove("Book 1");
            Console.WriteLine("Books in the library:");
            for (int i = 0; i < library.Count; i++)
            {
                Console.WriteLine(library[i]);
            }
            Console.WriteLine();
            if (library.Contains("Book 2"))
            {
                Console.WriteLine("Book 2 is in the library");
            }
            else
            {
                Console.WriteLine("Book 2 is not in the library");
            }

        }
    }
}