using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void SaveChanges();
        bool Commit();
        void Rollback();
    }
}
