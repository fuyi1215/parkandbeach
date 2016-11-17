using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    enum PlaceType
    {
        Park,
        Beach
    }
    public class Collection 
    {
        private List<Place> Placelist;
        //private List<Park> Parklist;
        //private List<Beach> Beachlist;

        public Collection()
        {
            Placelist = new List<Place>();
        }
        public Collection(List<Place> placelist)
        {
            Placelist = placelist;
        }

        

        public  void load()
        {
            Placelist = new List<Place>();
            var Parkurl = "http://data.southbend.opendata.arcgis.com/datasets/7a50910bc067491b80c0b3d92a9a5598_0.csv";
             Placelist = load(Parkurl, PlaceType.Park).ToList();
            var Beachurl = "https://data.michigan.gov/api/views/aiht-57sm/rows.csv?accessType=DOWNLOAD";
             Placelist.AddRange(load(Beachurl, PlaceType.Beach));
        }

        public void add()
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
                    var park = new Park(name, type, loc, zip);
                    Placelist.Add(park);
                    //parks.Add(new Park(name, type, loc, int.Parse(zip)));
                    Console.WriteLine("\nResults: \n" + park.ToString());
                    break;
                case "2":
                    Console.WriteLine("Name of the Beach:");
                    var Bname = Console.ReadLine();
                    Console.WriteLine("Phone Number of the Beach:");
                    var Bphone = Console.ReadLine();
                    Console.WriteLine("Location of the Beach:");
                    var Bloc = Console.ReadLine();
                    Console.WriteLine("Zip of the Beach:");
                    var BZip = Console.ReadLine();
                    Console.WriteLine("longitude and latitude of the Beach:");
                    var Blonglat = Console.ReadLine();
                    var beach = new Beach(Bname, Bloc, Bphone,BZip, Blonglat);
                    Placelist.Add(beach);
                    //parks.Add(new Park(name, type, loc, int.Parse(zip)));
                    Console.WriteLine("\nResults: \n" + beach.ToString());
                    break;
                default:
                    break;
            }
        }

        public void search()
        {
            Console.WriteLine("Enter search text:");
            var search = Console.ReadLine();
            int i;

             var Parksresults = Placelist.OfType<Park>().ToList<Park>().FindAll(
                 (r => (int.TryParse(search, out i) && (r.FID == i || r.zipcode .Contains(search)) 
                 || r.Park_Type.Contains(search) 
                 || r.Park_Name.Contains(search) 
                 || r.Location_1.Contains(search))));
            var beachesreults = Placelist.OfType<Beach>().ToList<Beach>().FindAll(
                r => (int.TryParse(search, out i) && (r.ID == i )
                 || r.phoneNumber.Contains(search)
                 || r.name.Contains(search)
                 || r.thelocation.Contains(search)));
            Console.WriteLine("\nResults: \n");
            foreach (var park in Parksresults)
                Console.WriteLine(park.ToString());
            foreach (var beach in beachesreults)
                Console.WriteLine(beach.ToString());
        }
        public void edit()
        {
            Console.WriteLine("Option 1) Edit a park");
            Console.WriteLine("Option 2) Edit a beach");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":

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
                    var park = Placelist.OfType<Park>().ToList<Park>().Find(p => p.FID == int.Parse(fid));
                    if (name.Length > 0) park.Park_Name = name;
                    if (type.Length > 0) park.Park_Type = type;
                    if (loc.Length > 0) park.Location_1 = loc;
                    if (zip.Length == 4) park.zip_code = zip;

                    Console.WriteLine("\nResults: \n" + park.ToString());
                    break;
                case "2":
                    Console.WriteLine("ID of Beach to edit:");
                    var Bid = Console.ReadLine();
                    Console.WriteLine("Name of the Beach:");
                    var Bname = Console.ReadLine();
                    Console.WriteLine("phone Number of the Beach:");
                    var Bphone = Console.ReadLine();
                    Console.WriteLine("Location of the Beach:");
                    var Bloc = Console.ReadLine();
                    //Console.WriteLine("Zip of the park:");
                    //var Bzip = Console.ReadLine();
                    var Beach = Placelist.OfType<Beach>().ToList<Beach>().Find(p => p.ID == int.Parse(Bid));
                    if (Bname.Length > 0) Beach.name = Bname;
                    if (Bphone.Length > 0)Beach.phoneNumber = Bphone;
                    if (Bloc.Length > 0) Beach.thelocation = Bloc;
                    

                    Console.WriteLine("\nResults: \n" + Beach.ToString());
                    break;
                default:
                    break;
            }
        }

      

        public void display()
        {
            Console.WriteLine( this.ToString());
        }


        // = Placelist.OfType<Park>

        public void Linq()
        {
            Console.WriteLine("Option 1) Get Total Number of Beachs");
            Console.WriteLine("Option 2) Get Total Number of Type Parks");
            Console.WriteLine("Option 3) Get Mutilevel Ordering for the name, address");
            Console.WriteLine("Option 4) Get Location Join the table");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    var TN_B = Placelist.OfType<Beach>().ToList().FindAll(v => v.theType == "Beach").Count();
                    Console.WriteLine("Total Number of beach:" + TN_B.ToString());
                    break;
                case "2":
                    var NumberTypequary = from p in Placelist
                                          where !string.IsNullOrEmpty(p.theType)
                                          group p by p.theType into ty

                                          select new { TN = ty.Count(), P = ty.Key };
                    foreach (var item in NumberTypequary)
                        Console.WriteLine(item.P + " " + item.TN);
                    break;
                case "3":

                    var AphaNamequary = from p in Placelist
                                        orderby p.name ascending, p.theType descending, p.thelocation
                                        select new { p.name, p.theType };
                    foreach (var item in AphaNamequary)
                        Console.WriteLine("Name:" + item.name + " Type: " + item.theType);

                    break;
                case "4":
                    var Locationsql = from p in Placelist.OfType<Park>()
                                      select new
                                      {
                                          ID = p.FID,
                                          Location = p.Location_1.Substring(0, p.Location_1.IndexOf('(')),
                                          lnglat = p.Location_1.Substring(p.Location_1.IndexOf('('))
                                      };
                    //p.Location_1.Substring(2) };

                    var Joinsql = from p in Placelist.OfType<Park>()
                                  join L in Locationsql on p.FID equals L.ID
                                  select new { L.ID, p.Park_Name, Address = L.Location, LngLat = L.lnglat };
                    foreach (var item in Joinsql)
                        Console.WriteLine(item.Park_Name + " " + item.LngLat + " " + item.Address);
                    break;

                   
                default:
                    break;
            }
        }




        private IEnumerable<Place> load(string urlstring, PlaceType Ptype)
        {
            string _content = string.Empty;
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
                
                var parkRow = Place.CsvRow(_content).Skip(1);
                
                 return parkRow.Select(v => Park.FromCsv(v))
                               .OfType<Park>().ToList();
                

            }
            else
            {
                var BeachRow  = Place.CsvRow(_content).Skip(1);

                //Beaches = new List<Beach>();
                return BeachRow.Select(v => Beach.FromCsv(v)).OfType<Beach>()
                                  .ToList();
            }

        }
        public void add(Place p)
        {
            if(p is Beach)
            {
                Placelist.Add((Beach)p);
            }
            else
            {
                Placelist.Add((Park)p);
            }
        }
        public IEnumerable<Place> FindBeachName(string value)
        {

            //if (P is Beach)
            //{
            //return Placelist.FindAll((r => (int.TryParse(value, out i) && ( r.Zip == i) || r.Park_Type.Contains(search) || r.Park_Name.Contains(search) || r.Location_1.Contains(search))));
            List<Beach> beachlist = new List<Beach>();
            foreach(var Beach in Placelist.OfType<Beach>())
            {
                if(Beach.name.Contains(value))
                {
                    beachlist.Add(Beach);
                }
            }

            return beachlist;

        }
        
            //foreach (var park in Parks)
            //{
            //    if (park != null)
            //        Console.WriteLine(park.ToString());
            //}
            //foreach (var beach in Beaches)
            //{
            //    if (beach != null)
            //        Console.WriteLine(beach.ToString());
            //}
        public override string ToString()
        {
            string result = "\nResults: \n";
            Beach beach;
            Park park;
            foreach (var p in Placelist)
            {
                if (p is Beach)
                {
                    beach = p as Beach;
                   result += beach.ToString()+"\n";
                }
                else
                {
                    park = p as Park;
                    if(park != null)
                        result += park.ToString() + "\n";                   
                }
            }
            return result;
            
        }

    }
}
