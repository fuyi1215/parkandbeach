﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataModel
{
    public class Beach : Place
    {
        
        public int ID { get; set; }
        public int beachID {get; set;}
        public string phone { get; set; }

        public string County { get; set; }

        public string EnteranceFee { get; set; }

        public string PermitRequired { get; set; }

        public string UnitDescription { get; set; }

        public string TotalNumofSites { get; set; }
        public string Description { get; set; }
        public string Location_1 { get; set; }


        public string longlatitude { get; set; }
       
        public Beach() : base()
        {
            ID = id;
            base.Name = "";
            base.Location = "";
            base.Type = "Beach";
            base.Zip = 0;
        }
        public Beach(string Name, string Location, string Type, int Zip)
            :base(Name,Location,Type,Zip)
        {
            ID = id;
            base.Name = Name;
            base.Location = Location;
            base.Type = "Beach";
            base.Zip = Zip;
            
        }
        public static Beach FromCsv(string csvLine)
        {


            string[] values = Csvsplit(csvLine);


            //string[] values = csvLine.Split(',');
            
            if (values.Length < 9)
            {
                return null;
            }
            else
            {
                Beach beach = new Beach();
                beach.beachID = string.IsNullOrEmpty(values[0]) ? 0 : Convert.ToInt32(values[0]);
                beach.Name = values[1];
                beach.phone = values[2];
                beach.County = values[3];
                beach.EnteranceFee = values[4];
                beach.PermitRequired = values[5];
                beach.UnitDescription = values[6];
                beach.TotalNumofSites = values[7];
                beach.Description = values[8];
                beach.longlatitude = values[9];
                return beach;
            }
        }
        public override string ToString()
        {
            return  string.Format("ID:{0,3}  Name:{1,10}  Park Type: {2,5}  PhoneNumber:{3,10}  Location: {4}"
                                   ,ID, Name, base.Type, phone, longlatitude.ToString());
        }

        
    }
}
