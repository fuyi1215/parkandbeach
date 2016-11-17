using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace P3_FRANKYIFU
{
    //enum PlaceType
    //{
    //    Park,
    //    Beach
    //}

    class Program
    {
      
        //private static Collection placelist;
        private static List<Park> Parks = new List<Park>();
        private static List<Beach> Beaches = new List<Beach>();
        //private static List<Place> Places;
        private static readonly int[] _indexWeNeed = { 0, 1, 47, 2 };
        static void Main(string[] args)
        {
            Collection placeDB = new Collection();   
            while (true)
            {

                Console.WriteLine("Menu Options:");
                Console.WriteLine("Option 0) Clear stored data and Load data to your program");
                Console.WriteLine("Option 1) Add an item");
                Console.WriteLine("Option 2) Modify an item through user input");
                Console.WriteLine("Option 3) Search based on user input and display the matched results");
                Console.WriteLine("Option 4) Display count of all the stored items");
                Console.WriteLine("Option 5) Display Linq of stored items");
                Console.WriteLine("Option 6) Exit");
                var input = Console.ReadLine();
                if (input == "0") placeDB.load();
                else if (input == "1") placeDB.add();
                else if (input == "2") placeDB.edit();
                else if (input == "3") placeDB.search();
                else if (input == "4") placeDB.display();
                else if (input == "5") placeDB.Linq();
                else if (input == "6") break;

                else
                    Console.WriteLine("Invalid Input. Please try again");
                Console.WriteLine("\n\n");
            }
        }
       
        private List<Place> GetAllOrder()
        {
            return Parks.Cast<Place>().Concat(Beaches.Cast<Place>()).ToList();
        }

        //https://data.michigan.gov/api/views/aiht-57sm/rows.csv?accessType=DOWNLOAD
        //https://docs.google.com/spreadsheets/d/1kRexxHe4HAUXWoN-8yC3k0FCMReBew3aA4swmCvIqKI/pub?output=csv
        

       
       


       
           
        }
        
        

    }




