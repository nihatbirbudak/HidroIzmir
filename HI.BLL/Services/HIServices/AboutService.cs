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
    public class AboutService : IAboutService
    {
        private readonly IUnitofWork uow;

        public AboutService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public bool deleteEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<About> getAll()
        {
            throw new NotImplementedException();
        }

        public About getEntity(int entityId)
        {
            return uow.GetRepository<About>().GetAll().FirstOrDefault();
        }

        public About getEntityByName(string entityName)
        {
            throw new NotImplementedException();
        }

        public List<About> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public About newEntity(About entity)
        {
            throw new NotImplementedException();
        }

        public About updateEntity(About entity)
        {
            var selected = uow.GetRepository<About>().Get(z => z.Id == entity.Id);
            selected = entity;
            uow.GetRepository<About>().Update(selected);
            uow.SaveChanges();
            return selected;
        }
    }
}
