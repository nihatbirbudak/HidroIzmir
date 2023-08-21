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
    public class ImagePathService : IimagePathService
    {
        private readonly IUnitofWork uow;
        public ImagePathService(IUnitofWork uow) 
        { 
            this.uow = uow; 
        }
        public bool deleteEntity(int entityId)
        {
            try
            {
                var path = uow.GetRepository<ImagePath>().Get(z => z.Id == entityId);
                uow.GetRepository<ImagePath>().Delete(path);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ImagePath> getAll()
        {
            return uow.GetRepository<ImagePath>().GetAll().ToList();
        }

        public ImagePath getEntity(int entityId)
        {
            return uow.GetRepository<ImagePath>().Get(z => z.Id==entityId);
        }

        public ImagePath getEntityByName(string entityName)
        {
            throw new NotImplementedException();
        }

        public List<ImagePath> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public ImagePath newEntity(ImagePath entity)
        {
            if (!uow.GetRepository<ImagePath>().GetAll().Any(z => z.Path == entity.Path))
            {
                entity = uow.GetRepository<ImagePath>().Add(entity);
                uow.SaveChanges();
                return entity;
            }
            else
            {
                return null;
            }
        }

        public ImagePath updateEntity(ImagePath entity)
        {
            var selected = uow.GetRepository<ImagePath>().Get(z => z.Id == entity.Id);
            selected = entity;
            uow.GetRepository<ImagePath>().Update(selected);
            return selected;
        }
        public List<ImagePath> getImagePathtoProdcutId(int id)
        {
            var selectList = uow.GetRepository<ImagePath>().Get(z => z.ProductId == id,null,null,null).ToList();
            return selectList;
        }
    }
}
