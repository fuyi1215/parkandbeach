using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_FRANKYIFU
{
    class Program
    {
        private static string _content;
        private Collection list;
        private static readonly int[] _indexWeNeed = { 0, 1, 47, 2 };
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Menu Options:");
                Console.WriteLine("Option 0) Clear stored data and Load data to your program");
                Console.WriteLine("Option 1) Add an item");
                Console.WriteLine("Option 2) Modify an item through user input");
                Console.WriteLine("Option 3) Search based on user input and display the matched results");
                Console.WriteLine("Option 4) Display count of all the stored items");
                Console.WriteLine("Option 5) exit");
                var input = Console.ReadLine();
                if (input == "0") load();
                else if (input == "1") add();
                else if (input == "2") edit();
                else if (input == "3") search();
                else if (input == "4") display();
                else if (input == "5") break;
                else
                    Console.WriteLine("Invalid Input. Please try again");
                Console.WriteLine("\n\n");
            }
        }
    }


    
}
