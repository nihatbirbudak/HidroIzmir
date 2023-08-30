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
    public class SliderService : ISliderService
    {
        private readonly IUnitofWork uow;
        public SliderService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public bool deleteEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<Slider> getAll()
        {
            throw new NotImplementedException();
        }

        public Slider getEntity(int entityId)
        {
            return uow.GetRepository<Slider>().Get(z => z.Id == entityId);
        }

        public Slider getEntityByName(string entityName)
        {
            throw new NotImplementedException();
        }

        public List<Slider> getEntityName(string entityName)
        {
            throw new NotImplementedException();
        }

        public Slider newEntity(Slider entity)
        {
            throw new NotImplementedException();
        }

        public Slider updateEntity(Slider entity)
        {
            var selected = uow.GetRepository<Slider>().Get(z => z.Id == entity.Id);
            selected = entity;
            uow.GetRepository<Slider>().Update(selected);
            uow.SaveChanges();
            return selected;
        }
    }
}
