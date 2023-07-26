using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.Core.Services
{
    public interface IServiceBase<T>
    {
        List<T> getAll();
        T getEntity(int entityId);
        List<T> getEntityName(string entityName);
        T getEntityByName(string entityName);
        T newEntity(T entity);
        T updateEntity(T entity);
        bool deleteEntity(int entityId);
    }
}
