using System.Collections.Generic;
using DnDCMSLibrary.Entities;

namespace DnDCMSLibrary.Interfaces
{
    interface ISpellRepository
    {
        List<Spell> GetAllSpells();

        List<Spell> GetSearchedSpell(string query);
    }
}
