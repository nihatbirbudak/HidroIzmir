using HI.BLL.Services.Abstract;
using HI.Core.Data.UnitOfWork;
using HI.Model;

namespace HI.BLL.Services.HIServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork uow;
        public CategoryService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEntity(int entityId)
        {
            try
            {
                var category = uow.GetRepository<Category>().Get(z => z.Id == entityId);
                uow.GetRepository<Category>().Delete(category);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public List<Category> getAll()
        {
            var category = uow.GetRepository<Category>().GetAll().ToList();
            return category;
        }

        public Category getEntity(int entityId)
        {
            var category = uow.GetRepository<Category>().Get(z =>z.Id == entityId);
            return category;
        }

        public Category getEntityByName(string entityName)
        {
            return uow.GetRepository<Category>().Get(z => z.Name == entityName);
        }

        public List<Category> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public Category newEntity(Category entity)
        {
            if (!uow.GetRepository<Category>().GetAll().Any(z => z.Name == entity.Name)) { 
                entity = uow.GetRepository<Category>().Add(entity);
                uow.SaveChanges();
                return entity;
            }
            else
            {
                return null;
            }
        }

        public Category updateEntity(Category entity)
        {
            var selected = uow.GetRepository<Category>().Get(z => z.Id == entity.Id);
            selected = entity;
            uow.GetRepository<Category>().Update(selected);
            uow.SaveChanges();
            return selected;
        }
    }
}
