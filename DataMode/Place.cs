using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Place
    {
        protected string id;
        protected string Name;
        protected string location;
        protected string Type;
        protected string zip;


        public override string ToString()
        {
            
            return  id + Name + location + Type + zip;
        }

    }

    
}
