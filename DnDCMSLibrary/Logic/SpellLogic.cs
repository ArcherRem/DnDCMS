﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCMSLibrary.Entities;
using DnDCMSLibrary.Repositories;
using DnDCMSLibrary.Interfaces;

namespace DnDCMSLibrary.Logic
{
    public class SpellLogic
    {
        private ISpellRepository repository = new SpellContext();

        public SpellLogic(ISpellRepository repository)
        {
            this.repository = repository;
        }
        public List<Spell> GetSpell (string query)
        {
            return repository.GetSpell(query);
        }
    }
}
