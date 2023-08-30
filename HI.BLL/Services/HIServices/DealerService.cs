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
    public class DealerService : IDealersService
    {
        private readonly IUnitofWork uow;
        public DealerService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public bool deleteEntity(int entityId)
        {
            try
            {
                var deleted = uow.GetRepository<Dealer>().Get(z => z.Id == entityId);
                uow.GetRepository<Dealer>().Delete(deleted);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Dealer> getAll()
        {
            return uow.GetRepository<Dealer>().GetAll().ToList();
        }

        public Dealer getEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public Dealer getEntityByName(string entityName)
        {
            throw new NotImplementedException();
        }

        public List<Dealer> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public Dealer newEntity(Dealer entity)
        {
            if (!uow.GetRepository<Dealer>().GetAll().Any(z => z.Name == entity.Name))
            {
                var added = uow.GetRepository<Dealer>().Add(entity);
                uow.SaveChanges();
                return added;
            }
            else
            {
                return null;
            }
        }

        public Dealer updateEntity(Dealer entity)
        {
            
            var selected = uow.GetRepository<Dealer>().Get(z => z.Id == entity.Id);
            selected = entity;
            uow.GetRepository<Dealer>().Update(selected);
            uow.SaveChanges();
            return selected;
        }
    }
}
