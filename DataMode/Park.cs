using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class Park
    {
        //":null,"":null,"":null,"
        //private int _AquaFeatPool;
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










    }
}
