using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCMSLibrary.Entities
{
    class Character
    {
        public string picturepath { get; private set; }
        public string race { get; }
        public string subrace { get; }
        public string background { get; }
        public string alignment { get; }
        public int level { get; }
        public int experience { get; }
        public int currenthp { get; }
        public int maxhp { get; }
        public string haircolor { get; }
        public string eyecolor { get; }
        public string skincolor { get; }
        public string gender { get; }
        public string height { get; }
        public string weight { get; }
        public int age { get; }

        public Character()
        {

        }
        public Character(string picturepath, string race, string subrace, string background, string alignment, int experience, int currenthp, int maxhp, string haircolor, string eyecolor, string skincolor, string gender, string height, string weight, int age)
        {
            this.picturepath = picturepath;
            this.race = race;
            this.subrace = subrace;
            this.background = background;
            this.alignment = alignment;
            this.experience = experience;
            this.currenthp = currenthp;
            this.maxhp = maxhp;
            this.haircolor = haircolor;
            this.eyecolor = eyecolor;
            this.skincolor = skincolor;
            this.gender = gender;
            this.height = height;
            this.weight = weight;
            this.age = age;

        }
    }
}
