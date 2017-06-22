using System.Collections.Generic;
using DnDCMSLibrary.Entities;

namespace DnDCMSLibrary.Interfaces
{
    public interface ISpellRepository
    {
        List<Spell> GetSpell(string query);
    }
}
