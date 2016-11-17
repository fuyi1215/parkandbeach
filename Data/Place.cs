using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataModel
{
    public class Place
    {
        //private string _zip;
        protected static int id = 0;
        private string Name;
        private string Location;
        private string Type;
        private int Zip;


        public Place()
        {
            id++;
            Name = string.Empty;
            Location = string.Empty;
            Type = string.Empty;
            Zip = 0;

        }
        public Place(string name, string loc, string type, int zip)
        {
            id++;
            Name = name;
            Location = loc;
            Type = type;
            Zip = zip; 
        }
        //property to get or set name
        public string name
        {
            get
            {
                return Name;
            } 
            set
            {
                Name = value;
            } 
        }

        //property to get or set location
        public string thelocation
        {
            get
            {
                return Location;
            }
            set
            {
                Location = value;
            }
        }

        //property to get or set location
        public string theType
        {
            get
            {
                return Type;
            }
            set
            {
                Type = value;
            }
        }

        //property to get or set zip
        public int  zip_code
        {
            get
            {
                return Zip;
            }
            set
            {
                
                Zip = value;
            }
        }






        public override string ToString()
        {
            
            return string.Format("ID:{0,3}  Name:{1,10},Park Type: {2,10} Zip:{3,7} Location: {4}"
                                    , id, Name, Type , Zip.ToString(), Location);
        }

        public static string[] Csvsplit(string csvline)
        {
            Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)");
            
            List<string> list = new List<string>();
            string curr = null;
            foreach (Match match in csvSplit.Matches(csvline))
            {
                curr = match.Value;
                if (0 == curr.Length)
                {
                    list.Add("");
                }
                list.Add(curr.TrimStart(','));
            }
            return list.ToArray<string>();
        }
        public static string[] CsvRow(string csv)
        {
            return Regex.Split(csv, "(?=(?:(?:[^\"]*\"){2})*[^\"]*$)\\n");

        }


    }

    
}
