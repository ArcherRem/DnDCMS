using System.Collections.Generic;
using DnDCMSLibrary.Entities;

namespace DnDCMSLibrary.Interfaces
{
    public interface IClassRepository
    {
        List<Class> GetClass(int id);
    }
}
