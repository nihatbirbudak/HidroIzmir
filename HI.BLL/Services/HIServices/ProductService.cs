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
    public class ProductService : IProductService
    {
        private readonly IUnitofWork uow;
        public  ProductService(IUnitofWork uow) {
            this.uow = uow;
        }
        public bool deleteEntity(int entityId)
        {
            try
            {
                var product = uow.GetRepository<Product>().Get(z => z.Id == entityId);
                uow.GetRepository<Product>().Delete(product);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> getAll()
        {
            return uow.GetRepository<Product>().GetAll().ToList();
        }

        public Product getEntity(int entityId)
        {
            return uow.GetRepository<Product>().Get(z => z.Id == entityId);
        }

        public Product getEntityByName(string entityName)
        {
            return uow.GetRepository<Product>().Get(z => z.Name == entityName);
        }

        public List<Product> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public Product newEntity(Product entity)
        {

            if (!uow.GetRepository<Product>().GetAll().Any(z => z.Name == entity.Name))
            {
                var added = uow.GetRepository<Product>().Add(entity);
                uow.SaveChanges();
                return added;
            }
            else
            {
                return null;
            }
        }

        public Product updateEntity(Product entity)
        {
            var selected = uow.GetRepository<Product>().Get(z => z.Id == entity.Id);
            selected = entity;
            uow.GetRepository<Product>().Update(selected);
            uow.SaveChanges();
            return selected;
        }
    }
}
