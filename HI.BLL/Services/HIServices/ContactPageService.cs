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
    public class ContactPageService : IContactPageService
    {
        private readonly IUnitofWork uow;

        public ContactPageService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public bool deleteEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<ContactPage> getAll()
        {
            throw new NotImplementedException();
        }

        public ContactPage getEntity(int entityId)
        {
            return uow.GetRepository<ContactPage>().GetAll().FirstOrDefault();
        }
        public ContactPage getEntity()
        {
            return uow.GetRepository<ContactPage>().GetAll().FirstOrDefault();
        }

        public ContactPage getEntityByName(string entityName)
        {
            throw new NotImplementedException();
        }

        public List<ContactPage> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public ContactPage newEntity(ContactPage entity)
        {
            throw new NotImplementedException();
        }

        public ContactPage updateEntity(ContactPage entity)
        {
            var selected = uow.GetRepository<ContactPage>().Get(z => z.Id == entity.Id);
            selected = entity;
            uow.GetRepository<ContactPage>().Update(selected);
            uow.SaveChanges();
            return selected;
        }
    }
}
