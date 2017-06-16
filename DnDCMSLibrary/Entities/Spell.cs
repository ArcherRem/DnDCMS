using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCMSLibrary.Entities
{
    class Spell
    {
        public int id;
        public string name { get; private set; }
        public string level { get; private set; }
        public string type { get; private set; }
        public bool ritual { get; private set; }
        public string effect { get; private set; }
        public string castingtime { get; private set; }
        public string range { get; private set; }
        public string components { get; private set; }
        public string duration { get; private set; }

        public Spell(int id, string name, string level, string type, bool ritual, string effect, string castingtime, string range, string components, string duration)
        {
            this.id = id;
            this.name = name;
            this.level = level;
            this.type = type;
            this.ritual = ritual;
            this.effect = effect;
            this.castingtime = castingtime;
            this.range = range;
            this.components = components;
            this.duration = duration;
        }
    }
}
