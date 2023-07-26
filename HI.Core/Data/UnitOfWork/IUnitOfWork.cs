using HI.Core.Data.Repositories;
using HI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.Core.Data.UnitOfWork
{
    public interface IUnitofWork
    {
        IRepository<T> GetRepository<T>() where T : Entity<int>;

        int SaveChanges();
    }
}
