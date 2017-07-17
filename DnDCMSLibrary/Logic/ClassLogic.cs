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
    public class ClassLogic
    {
        private IClassRepository repository = new ClassContext();

        public ClassLogic(IClassRepository repository)
        {
            this.repository = repository;
        }

        public List<Class> GetClass(int id)
        {
            return repository.GetClass(id);
        }
    }
}
