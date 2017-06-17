using System.Collections.Generic;
using DnDCMSLibrary.Entities;

namespace DnDCMSLibrary.Interfaces
{
    public interface ISpellRepository
    {
        List<Spell> GetAllSpells();

        List<Spell> GetSearchedSpell(string query);
    }
}
