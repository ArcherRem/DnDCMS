using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCMSLibrary.Entities
{
    class Class
    {
        public int Barbarian { get; }
        public int Bard { get; }
        public int Cleric { get; }
        public int Druid { get; }
        public int Fighter { get; }
        public int Monk { get; }
        public int Paladin { get; }
        public int Ranger { get; }
        public int Rogue { get; }
        public int Sorcerer { get; }
        public int Warlock { get; }
        public int Wizard { get; }

        public Class()
        {

        }
        public Class(int barbarian, int bard, int cleric, int druid, int fighter, int monk, int paladin, int ranger, int rogue, int sorcerer, int warlock, int wizard)
        {
            this.Barbarian = barbarian;
            this.Bard = bard;
            this.Cleric = cleric;
            this.Druid = druid;
            this.Fighter = fighter;
            this.Monk = monk;
            this.Paladin = paladin;
            this.Ranger = ranger;
            this.Rogue = rogue;
            this.Sorcerer = sorcerer;
            this.Warlock = warlock;
            this.Wizard = wizard;
        }
    }
}
