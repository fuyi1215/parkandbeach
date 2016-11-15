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
        private List<Beach> Beachlist;

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
            var Parkurl = "http://data.southbend.opendata.arcgis.com/datasets/7a50910bc067491b80c0b3d92a9a5598_0.csv";
             Placelist = load(Parkurl, PlaceType.Park).ToList();
            var Beachurl = "https://data.michigan.gov/api/views/aiht-57sm/rows.csv?accessType=DOWNLOAD";
             Placelist.AddRange(load(Beachurl, PlaceType.Beach));
        }

        public void display()
        {
            Console.WriteLine( this.ToString());
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
                var BeachRow = _content?.Split('\n').Skip(1);

                //Beaches = new List<Beach>();
                return BeachRow.Select(v => Beach.FromCsv(v))
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
                if(Beach.Name.Contains(value))
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
