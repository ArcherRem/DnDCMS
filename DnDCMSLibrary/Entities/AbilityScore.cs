using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCMSLibrary.Entities
{
    class AbilityScore
    {
        public decimal strength { get; private set; }
        public decimal dexterity { get; private set; }
        public decimal constitution { get; private set; }
        public decimal intelligence { get; private set; }
        public decimal wisdom { get; private set; }
        public decimal charisma { get; private set; }

        public AbilityScore()
        {

        }
        public AbilityScore(decimal strength, decimal dexterity, decimal constitution, decimal intelligence, decimal wisdom, decimal charisma)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.constitution = constitution;
            this.intelligence = intelligence;
            this.wisdom = wisdom;
            this.charisma = charisma;
        }
    }
}
