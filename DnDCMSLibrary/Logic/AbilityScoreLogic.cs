using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCMSLibrary.Repositories;
using DnDCMSLibrary.Entities;
using DnDCMSLibrary.Interfaces;

namespace DnDCMSLibrary.Logic
{
    class AbilityScoreLogic
    {
        private IAbilityScoreRepository repository = new AbilityScoreContext();
    }
}
