using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCMSLibrary.Entities;

namespace DnDCMSLibrary.Interfaces
{
    public interface IAbilityScoreRepository
    {
        List<AbilityScore> GetAbilityScores(int id);
    }
}
