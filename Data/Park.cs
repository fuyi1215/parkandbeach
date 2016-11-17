
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class Park : Place
    {
        
        
        public string Park_Name { get; set;}

        public string Park_Type { get; set; }
        
        public int Zip_Code { get; set; }

        //[JsonConverter(typeof(BoolConverter))]
        public int Aqua_Feat__Pool { get; set; }

        //[JsonConverter(typeof(BoolConverter))]
        public int Aqua_Feat__Spray { get; set; }

        public string Backstop__Practice { get; set; }
        public int Ballfield { get; set; }
        public double Basketball { get; set; }
        public int Blueway { get; set; }

        public string Complex__Ballfield { get; set; }
        public string Complex__Tennis { get; set; }

        public string Concessions { get; set; }

        public string Disk_Golf { get; set; }

        public string Driving_Range { get; set; }
        public int Educational_Experience { get; set; }
        public int Event_Space { get; set; }
        public string Fitness_Course { get; set; }
        public int Garden__Community { get; set; }
        public int Garden__Display { get; set; }
        public string Golf { get; set; }
        public string Hockey__Ice { get; set; }
        public int Loop_Walk { get; set; }
        public int MP_Field__Large { get; set; }
        public string MP_Field__Multiple { get; set; }
        public int MP_Field__Small { get; set; }
        public string Multiuse_Court { get; set; }
        public int Natural_Area { get; set; }
        public int Open_Turf { get; set; }
        public int Open_Water { get; set; }
        public string Other___Active { get; set; }
        public string Other_Passive { get; set; }
        public int Passive_Node { get;set;}
        public int Picnic_Grounds {get;set;}
        public int Playground__Destination { get; set; }
        public int Playground__local { get; set; }
        public int Public_Art { get; set; }
        public int Shelter { get; set; }
        public int Shelter__Group { get; set; }
        public int Skate_Park { get; set; }
        public string Sledding_Hill { get; set; }
        public int Structure { get; set; }
        public string Tennis { get; set; }
        public string Trail__Primitive { get; set; }
        public string Volleyball { get; set; }
        public int Water_Access__Developed { get; set; }
        public int Water_Access__General { get; set; }
        public int Water_Feature  { get; set; }
        public string Location_1 { get; set; }
        public int FID { get; set; }

        public Park():base()
        {
            FID = id;
            base.theType = Park_Type;
            base.name = Park_Name;
            base.thelocation = Location_1;
            base.zip_code = Zip_Code;
        }

        public Park(string Name, string location,string type, int zip):base(Name,location,type,zip)
        {
            FID = id;
            Park_Name = Name;
            Location_1 = location;
            Park_Type = type;
            Zip_Code = zip; 

        }

        public static Park FromCsv(string csvLine)
        {
            
            string[] values = Csvsplit(csvLine);
            if (values.Length < 48)
            {
                return null;
            }
            else
            {
                Park park = new Park();
                park.Park_Name = values[0];
                park.name = park.Park_Name;
                park.Park_Type = string.IsNullOrEmpty(values[1]) ? string.Empty: values[1] ;
                park.theType = park.Park_Type;
                park.Zip_Code = Convert.ToInt32(values[2]);
                park.zip_code = park.Zip_Code;
                park.Aqua_Feat__Pool = string.IsNullOrEmpty(values[3]) ? 0 : Convert.ToInt32(values[3]);
                park.Aqua_Feat__Spray = string.IsNullOrEmpty(values[4])? 0 : Convert.ToInt32(values[4]);
                park.Backstop__Practice = values[5];
                park.Ballfield = string.IsNullOrEmpty(values[6]) ? 0 : Convert.ToInt32(values[6]);
                park.Basketball = string.IsNullOrEmpty(values[7]) ? 0 : Convert.ToDouble(values[7]); 
                park.Blueway = string.IsNullOrEmpty(values[8]) ? 0 : Convert.ToInt32(values[8]);
                park.Complex__Ballfield = values[9];
                park.Complex__Tennis = values[10];
                park.Concessions = values[11];
                park.Disk_Golf = values[12];
                park.Driving_Range = values[13];
                park.Educational_Experience = string.IsNullOrEmpty(values[14]) ? 0 : Convert.ToInt32(values[14]);
                park.Event_Space = string.IsNullOrEmpty(values[15]) ? 0 : Convert.ToInt32(values[15]);
                park.Fitness_Course = values[16];
                park.Garden__Community = string.IsNullOrEmpty(values[17]) ? 0 : Convert.ToInt32(values[17]);
                park.Garden__Display = string.IsNullOrEmpty(values[18]) ? 0 : Convert.ToInt32(values[18]);
                park.Golf = values[19];
                park.Hockey__Ice = values[20];
                park.Loop_Walk = string.IsNullOrEmpty(values[21]) ? 0 : Convert.ToInt32(values[21]);
                park.MP_Field__Large = string.IsNullOrEmpty(values[22]) ? 0 : Convert.ToInt32(values[22]);
                park.MP_Field__Multiple = values[23];
                park.MP_Field__Small = string.IsNullOrEmpty(values[24]) ? 0 : Convert.ToInt32(values[24]);
                park.Multiuse_Court = values[25];
                park.Natural_Area = string.IsNullOrEmpty(values[26]) ? 0 : Convert.ToInt32(values[26]);
                park.Open_Turf = string.IsNullOrEmpty(values[27]) ? 0 : Convert.ToInt32(values[27]);
                park.Open_Water = string.IsNullOrEmpty(values[28]) ? 0 : Convert.ToInt32(values[28]);
                park.Other___Active = values[29];
                park.Other_Passive = values[30];
                park.Passive_Node = string.IsNullOrEmpty(values[31]) ? 0 : Convert.ToInt32(values[31]);
                park.Picnic_Grounds = string.IsNullOrEmpty(values[32]) ? 0 : Convert.ToInt32(values[32]);
                park.Playground__Destination = string.IsNullOrEmpty(values[33]) ? 0 : Convert.ToInt32(values[33]);
                park.Playground__local = string.IsNullOrEmpty(values[34]) ? 0 : Convert.ToInt32(values[34]);
                park.Public_Art = string.IsNullOrEmpty(values[35]) ? 0 : Convert.ToInt32(values[35]);
                park.Shelter = string.IsNullOrEmpty(values[36]) ? 0 : Convert.ToInt32(values[36]);
                park.Shelter__Group = string.IsNullOrEmpty(values[37]) ? 0 : Convert.ToInt32(values[37]);
                park.Skate_Park = string.IsNullOrEmpty(values[38]) ? 0 : Convert.ToInt32(values[38]);
                park.Sledding_Hill = values[39];
                park.Structure = string.IsNullOrEmpty(values[40]) ? 0 : Convert.ToInt32(values[40]);
                park.Tennis = values[41];
                park.Trail__Primitive = values[42];
                park.Volleyball = values[43];
                park.Water_Access__Developed = string.IsNullOrEmpty(values[44]) ? 0 : Convert.ToInt32(values[44]);
                park.Water_Access__General = string.IsNullOrEmpty(values[45]) ? 0 : Convert.ToInt32(values[45]);
                park.Water_Feature = string.IsNullOrEmpty(values[46]) ? 0 : Convert.ToInt32(values[46]);
                park.Location_1 = values[47];
                park.thelocation = park.Location_1.Substring(0,park.Location_1.IndexOf('('));
                park.FID = string.IsNullOrEmpty(values[48]) ? 0 : Convert.ToInt32(values[48]);
                return park;
            }
       
    }
        public override string ToString()
        {
            return string.Format( "ID:{0,3}  Name:{1,10},Park Type: {2,10} Zip:{3,7} Location: {4}" ,FID, Park_Name,  Park_Type , Zip_Code,Location_1);
        }








    }
}
