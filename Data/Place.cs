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
