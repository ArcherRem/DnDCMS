using System.Collections.Generic;
using DnDCMSLibrary.Entities;

namespace DnDCMSLibrary.Interfaces
{
    public interface ICharacterRepository
    {
        List<Character> GetCharacter();
    }
}
