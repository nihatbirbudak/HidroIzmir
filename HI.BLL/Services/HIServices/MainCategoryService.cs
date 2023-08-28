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
    public class MainCategoryService : IMainCategoryService
    {
        private readonly IUnitofWork uow;
        public MainCategoryService(IUnitofWork uow) 
        {
            this.uow = uow;
        }
        public bool deleteEntity(int entityId)
        {
            try
            {
                var mainCategory = uow.GetRepository<MainCategory>().Get(z => z.Id == entityId);
                uow.GetRepository<MainCategory>().Delete(mainCategory);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public List<MainCategory> getAll()
        {
            return uow.GetRepository<MainCategory>().GetAll().ToList();
        }

        public MainCategory getEntity(int entityId)
        {
            return uow.GetRepository<MainCategory>().Get(z => z.Id==entityId);
        }

        public MainCategory getEntityByName(string entityName)
        {
            return uow.GetRepository<MainCategory>().Get(z => z.Name == entityName);
        }

        public List<MainCategory> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public MainCategory newEntity(MainCategory entity)
        {
            if (!uow.GetRepository<MainCategory>().GetAll().Any(z => z.Name == entity.Name))
            {
                entity = uow.GetRepository<MainCategory>().Add(entity);
                uow.SaveChanges();
                return entity;
            }
            else
            {
                return null;
            }
        }

        public MainCategory updateEntity(MainCategory entity)
        {
            var selected = uow.GetRepository<MainCategory>().Get(z => z.Id == entity.Id);
            selected = entity;
            uow.GetRepository<MainCategory>().Update(selected);
            uow.SaveChanges();
            return selected;

        }
    }
}
