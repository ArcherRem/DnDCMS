using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCMSLibrary.Entities
{
    class Skill
    {
        public bool acrobatics { get; set; }
        public bool animalhandling { get; set; }
        public bool arcana { get; set; }
        public bool athletics { get; set; }
        public bool deception { get; set; }
        public bool history { get; set; }
        public bool insight { get; set; }
        public bool intimidation { get; set; }
        public bool investigation { get; set; }
        public bool medicine { get; set; }
        public bool nature { get; set; }
        public bool perception { get; set; }
        public bool performance { get; set; }
        public bool persuasion { get; set; }
        public bool religion { get; set; }
        public bool sleightofhand { get; set; }
        public bool stealth { get; set; }
        public bool survival { get; set; }

        public Skill()
        {

        }
        public Skill(bool acrobatics, bool animalhandling, bool arcana, bool athletics, bool deception, bool history, bool insight, bool intimidation, bool investigation, bool medicine, bool nature, bool perception, bool performance, bool persuasion, bool religion, bool sleightofhand, bool stealth, bool survival)
        {
            this.acrobatics = acrobatics;
            this.animalhandling = animalhandling;
            this.arcana = arcana;
            this.athletics = athletics;
            this.deception = deception;
            this.history = history;
            this.insight = insight;
            this.intimidation = intimidation;
            this.investigation = investigation;
            this.medicine = medicine;
            this.nature = nature;
            this.perception = perception;
            this.performance = performance;
            this.persuasion = persuasion;
            this.religion = religion;
            this.sleightofhand = sleightofhand;
            this.stealth = stealth;
            this.survival = survival;
        }
    }
}
