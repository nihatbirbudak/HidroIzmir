using HI.BLL.Services.Abstract;
using HI.Core.Data.UnitOfWork;
using HI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.BLL.Services.HIServices
{
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork uow;
        public RoleService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public bool deleteEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<Role> getAll()
        {
            throw new NotImplementedException();
        }

        public Role getEntity(int entityId)
        {
            return uow.GetRepository<Role>().Get(z => z.Id == entityId);
        }

        public Role getEntityByName(string entityName)
        {
            throw new NotImplementedException();
        }

        public List<Role> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public Role newEntity(Role entity)
        {
            throw new NotImplementedException();
        }

        public Role updateEntity(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
