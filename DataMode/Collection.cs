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
        List<Place> Placelist;
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
            var Parkurl = "https://docs.google.com/spreadsheets/d/1kRexxHe4HAUXWoN-8yC3k0FCMReBew3aA4swmCvIqKI/pub?output=csv";
            load(Parkurl, PlaceType.Park);
            var Beachurl = "https://data.michigan.gov/api/views/aiht-57sm/rows.csv?accessType=DOWNLOAD";
            load(Beachurl, PlaceType.Beach);
        }
        private void load(string urlstring, PlaceType Ptype)
        {
            string _content = string.Empty;
            //using (var url = new WebClient())
            //{
            //    try
            //    {
            //        _content =
            //            url.DownloadString(urlstring);

            //    }
            //    catch (WebException e)
            //    {
            //        throw e;
            //    }
            //}
            //if (Ptype == PlaceType.Park)
            //{
            //    var parkRow = _content.Split('\n').Skip(1);

            //    Placelist = new List<Place>();
            //    List<Park> Parks = parkRow.Select(v => Park.FromCsv(v))
            //                   .OfType<Park>().ToList();
            //    Collection park = new Collection();
                
            //}
            //else
            //{
            //    var BeachRow = _content?.Split('\n').Skip(1);

            //    //Beaches = new List<Beach>();
            //    var Beaches = BeachRow.Select(v => Beach.FromCsv(v))
            //                      .ToList();
            //}
           
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
        public List<Beach> FindBeachName(string value)
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

        public override string ToString()
        {
            Beach beach;
            Park park;
            foreach (var p in Placelist)
            {
                if (p is Beach)
                {
                    beach = p as Beach;
                   return beach.ToString();
                }
                else
                {
                    park = p as Park;
                    return park.ToString();
                    
                }
                    

            }
            return null;
        }

    }
}
