using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Place
    {
        protected static int id = 0;
        public string Name;
        public string Location;
        public string Type;
        public int Zip;


        public Place()
        {
            id++;

        }
        public Place(string name, string loc, string type, int zip)
        {
            id++;
            Name = name;
            Location = loc;
            Type = type;
            Zip = zip; 
        }

        public override string ToString()
        {
            
            return  id + Name + Location + Type + Zip.ToString();
        }

    }

    
}
