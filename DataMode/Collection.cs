using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Collection
    {
        private List<Place> listplace = new List<Place>();
        public Collection()
        {
            
        }

        public Collection(List<Place> place)
        {
            listplace = place;
        }
        public void addplace(Place p)
        {
            listplace.Add(p);
        }

        public override string ToString()
        {
            var str = string.Format("{0,10}  {1,20} {2,4} {3,20} {4,6}\n", "Name" ,"Type","Location","Zip");
            foreach(var place in listplace)
            {
                if (place != null)
                {
                    string list = place.ToString();
                    str += list;
                }
            }
            
            return str;
        }
    }
}
