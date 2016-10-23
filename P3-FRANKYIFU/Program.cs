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
    enum PlaceType
    {
        Park,
        Beach
    }

    class Program
    {
        private static string _content;
        //private static Collection placelist;
        private static List<Park> Parks = new List<Park>();
        private static List<Beach> Beaches = new List<Beach>();
        //private static List<Place> Places;
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
        private static void load()
        {
            
            var url = "https://docs.google.com/spreadsheets/d/1kRexxHe4HAUXWoN-8yC3k0FCMReBew3aA4swmCvIqKI/pub?output=csv";
            load(url, PlaceType.Park);
               url = "https://data.michigan.gov/api/views/aiht-57sm/rows.csv?accessType=DOWNLOAD";
            load(url, PlaceType.Beach);

        }
        private List<Place> GetAllOrder()
        {
            return Parks.Cast<Place>().Concat(Beaches.Cast<Place>()).ToList();
        }

        //https://data.michigan.gov/api/views/aiht-57sm/rows.csv?accessType=DOWNLOAD
        //https://docs.google.com/spreadsheets/d/1kRexxHe4HAUXWoN-8yC3k0FCMReBew3aA4swmCvIqKI/pub?output=csv
        private static void load(string urlstring, PlaceType Ptype)
        {
            using (var url = new WebClient())
            {
                try
                {
                    _content =
                        url.DownloadString(urlstring);

                }
                catch (WebException e)
                {
                    throw e;
                }
            }
            if (Ptype == PlaceType.Park)
            {
                var parkRow = _content.Split('\n').Skip(1);

                //Parks = new List<Park>();
                Parks = parkRow.Select(v => Park.FromCsv(v))
                               .OfType<Park>().ToList();
            }
            else
            {
                var BeachRow = _content?.Split('\n').Skip(1);

                //Beaches = new List<Beach>();
                Beaches = BeachRow.Select(v => Beach.FromCsv(v))
                                  .ToList();
            }
            //foreach (var i in parkRow)
            //{
            //    var contentArr = i?.Split(',');
            //    if (contentArr.Length < 48)
            //        continue;
            //    var result = _indexWeNeed.Select(j => contentArr?[j]).ToArray();

            //    //Parks.Add(new Park(result));
            //}
        }
        //private static void load(string urlstring, PlaceType pType)
        //{
        //    using (var url = new WebClient())
        //    {
        //        try
        //        {
        //            _content =
        //                url.DownloadString(urlstring);

        //        }
        //        catch (WebException e)
        //        {
        //            throw e;
        //        }
        //    }
        //    Beaches = JsonConvert.DeserializeObject<List<Beach>>(_content);

        //}

        private static void search()
        {
            Console.WriteLine("Enter search text:");
            var search = Console.ReadLine();
            int i;
            var results = Parks.FindAll((r => (int.TryParse(search, out i) && (r.FID == i || r.Zip_Code == i) || r.Park_Type.Contains(search) || r.Park_Name.Contains(search) || r.Location_1.Contains(search))));
            Console.WriteLine("\nResults: \n");
            foreach (var park in results)
                Console.WriteLine(park.ToString());
        }
        private static void display()
        {
            Console.WriteLine("\nResults: \n");
            foreach (var park in Parks)
            {
                if(park != null)
                    Console.WriteLine(park.ToString());
            }
            foreach(var beach in Beaches)
            {
                if (beach != null)
                    Console.WriteLine(beach.ToString());
            }
        }
        private static void edit()
        {

            Console.WriteLine("FID of park to edit:");
            var fid = Console.ReadLine();
            Console.WriteLine("Name of the park:");
            var name = Console.ReadLine();
            Console.WriteLine("Type of the park:");
            var type = Console.ReadLine();
            Console.WriteLine("Location of the park:");
            var loc = Console.ReadLine();
            Console.WriteLine("Zip of the park:");
            var zip = Console.ReadLine();
            var park = Parks.Find(p => p.FID == int.Parse(fid));
            if (name.Length > 0) park.Park_Name = name;
            if (type.Length > 0) park.Park_Type = type;
            if (loc.Length > 0) park.Location_1 = loc;
            if (zip.Length > 0) park.Zip_Code = int.Parse(zip);

            Console.WriteLine("\nResults: \n" + park.ToString());
        }
        private static void add()
        {
            Console.WriteLine("Option 1) add a park");
            Console.WriteLine("Option 2) add a beach");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Name of the park:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Type of the park:");
                    var type = Console.ReadLine();
                    Console.WriteLine("Location of the park:");
                    var loc = Console.ReadLine();
                    Console.WriteLine("Zip of the park:");
                    var zip = Console.ReadLine();
                    Parks.Add(new Park(name, type, loc, Int32.Parse(zip)));

                    //parks.Add(new Park(name, type, loc, int.Parse(zip)));
                    Console.WriteLine("\nResults: \n" + Parks.Find(P => P.Park_Name == name).ToString());
                    break;
                case "2":
                    Console.WriteLine("Name of the Beach:");
                    var Bname = Console.ReadLine();
                    Console.WriteLine("Type of the Beach:");
                    var Btype = Console.ReadLine();
                    Console.WriteLine("Location of the Beach:");
                    var Bloc = Console.ReadLine();
                    Console.WriteLine("Zip of the Beach:");
                    var Bzip = Console.ReadLine();
                    Beaches.Add(new Beach(Bname, Btype, Bloc, Int32.Parse(Bzip)));

                    //parks.Add(new Park(name, type, loc, int.Parse(zip)));
                    Console.WriteLine("\nResults: \n" + Beaches.Find(P => P.Name == Bname).ToString());
                    break;
                default:
                    break;
            } 

           
        }
        
        

    }



}
