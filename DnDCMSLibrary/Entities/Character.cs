using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCMSLibrary.Entities
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; }
        public string picturepath { get; set; }
        public string race { get;  set; }
        public string subrace { get;  set; }
        public string background { get;  set; }
        public string alignment { get;  set; }
        public int level { get;  set; }
        public int experience { get;  set; }
        public int currenthp { get;  set; }
        public int maxhp { get;  set; }
        public string haircolor { get;  set; }
        public string eyecolor { get;  set; }
        public string skincolor { get;  set; }
        public string gender { get;  set; }
        public string height { get;  set; }
        public string weight { get;  set; }
        public int age { get;  set; }

        public override string ToString()
        {
            return name;
        }
    }
}
