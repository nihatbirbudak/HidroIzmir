using HI.BLL.Services.Abstract;
using HI.Core.Data.UnitOfWork;
using HI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HI.BLL.Services.HIServices
{
    public class ContactService : IContactService
    {
        private readonly IUnitofWork uow;
        public ContactService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEntity(int entityId)
        {
            try
            {
                var contact = uow.GetRepository<Contact>().Get(z => z.Id == entityId);
                uow.GetRepository<Contact>().Delete(contact);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Contact> getAll()
        {
            return uow.GetRepository<Contact>().GetAll().ToList();
        }

        public Contact getEntity(int entityId)
        {
            return uow.GetRepository<Contact>().Get(z =>z.Id == entityId);
        }

        public Contact getEntityByName(string entityName)
        {
            throw new NotImplementedException();
        }

        public List<Contact> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public Contact newEntity(Contact entity)
        {
            var added = uow.GetRepository<Contact>().Add(entity);
            uow.SaveChanges();
            return added;
        }

        public Contact updateEntity(Contact entity)
        {
            var selected = uow.GetRepository<Contact>().Get(z =>z.Id == entity.Id);
            selected = entity;
            uow.GetRepository<Contact>().Update(selected);
            uow.SaveChanges();
            return selected;
        }

        public List<Contact> getIsRead()
        {
            return uow.GetRepository<Contact>().GetAll().Where(z => z.IsRead == false).ToList();
        }
    }
}
