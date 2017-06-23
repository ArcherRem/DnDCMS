using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCMSLibrary.Entities;

namespace DnDCMS.ViewModel
{
    public class AbilityScoreViewModel
    {
        public List<AbilityScore> AbilityScores { get; set; }

        public AbilityScore SelectedAbilityScore { get; set; }
    }
}
