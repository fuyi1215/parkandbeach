using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Beach : Place
    {
        public string name { get; set; }
        public string phone { get; set; }

        public string County { get; set; }
        public string Location_1 { get; set; }

       
        public Beach() : base()
        {
            base.Name = name;
            base.location = Location_1;
            base.Type = "beach";
            base.zip = string.Empty;
        }

        public override string ToString()
        {
            return name + location + base.Type + base.zip;
        }
    }
}
