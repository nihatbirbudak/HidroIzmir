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
    public class UserService : IUserService
    {
        private readonly IUnitofWork uow;
        public UserService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public void changeRememberMe(User user)
        {
            throw new NotImplementedException();
        }

        public bool deleteEntity(int entityId)
        {
            try
            {
                var user = uow.GetRepository<User>().Get(z => z.Id == entityId);
                uow.GetRepository<User>().Delete(user);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User FindwithUsernameandMail(string mailorUserName, string Password)
        {
            var user =  uow.GetRepository<User>().Get(z => z.Password == Password && z.Email == mailorUserName);
            return user;
        }

        public List<User> getAll()
        {
            return uow.GetRepository<User>().GetAll().ToList();
        }

        public List<User> getAllUserinRole(int UserId)
        {
            throw new NotImplementedException();
        }

        public User getEntity(int entityId)
        {
            return uow.GetRepository<User>().Get(z =>z.Id == entityId);
        }

        public User getEntityByName(string entityName)
        {
            return uow.GetRepository<User>().Get(z =>z.Name == entityName);
        }

        public List<User> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public User newEntity(User entity)
        {
            if (!uow.GetRepository<User>().GetAll().Any(z => z.Email == entity.Email))
            {
                var added = entity;
                added = uow.GetRepository<User>().Add(added);
                uow.SaveChanges();
                return added;
            }
            else
            {
                return null;
            }
        }

        public User updateEntity(User entity)
        {
            var selected = uow.GetRepository<User>().Get(z =>z.Id == entity.Id);
            selected = entity;
            uow.GetRepository<User>().Update(selected);
            uow.SaveChanges();
            return selected;
        }
    }
}
