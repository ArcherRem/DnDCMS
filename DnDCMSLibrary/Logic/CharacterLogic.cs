using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCMSLibrary.Entities;
using DnDCMSLibrary.Repositories;
using DnDCMSLibrary.Interfaces;

namespace DnDCMSLibrary.Logic
{
    public class CharacterLogic
    {
        private ICharacterRepository repository = new CharacterContext();
        
        public CharacterLogic(ICharacterRepository repository)
        {
            this.repository = repository;
        }

        public List<Character> GetCharacter()
        {
            return repository.GetCharacter();
        }
        public List<Character> GetCharacterByID(int id)
        {
            return repository.GetCharacterByID(id);
        }

    }
}
