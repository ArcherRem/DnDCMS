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
    public class SkillLogic
    {
        private ISkillRepository repository = new SkillContext();

        public SkillLogic(ISkillRepository repository)
        {
            this.repository = repository;
        }

        public List<Skill> GetSkills(int id)
        {
            return repository.GetSkills(id);
        }
    }
}
