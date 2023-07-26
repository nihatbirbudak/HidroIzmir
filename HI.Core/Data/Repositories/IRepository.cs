﻿using HI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HI.Core.Data.Repositories
{ 
    public interface IRepository<T> where T : IEntity<int>
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter = null);
        T GetIncludes(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        IQueryable<T> Get(params Expression<Func<T, object>>[] includes);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
                          Expression<Func<T, object>> include = null);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
                          Expression<Func<T, object>> include = null,
                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                          int? skip = null,
                          int? take = null);
    }

}
