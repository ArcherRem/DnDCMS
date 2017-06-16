using System.Collections.Generic;
using DnDCMSLibrary.Entities;

namespace DnDCMSLibrary.Interfaces
{
    interface ICharacterRepository
    {
        List<Character> GetCharacter();
    }
}
