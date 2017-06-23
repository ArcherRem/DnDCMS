using System.Collections.Generic;
using DnDCMSLibrary.Entities;

namespace DnDCMSLibrary.Interfaces
{
    public interface ISkillRepository
    {
        List<Skill> GetSkills(int id);
    }
}
