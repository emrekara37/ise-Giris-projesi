using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TeknolivaProje.Core.Infrastructure
{
  public interface IRepository<TEntity> where TEntity:class
  {
    IEnumerable<TEntity> GetAll();
    TEntity GetById(int id);
    TEntity Get(Expression<Func<TEntity, bool>> expression);
    IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression);
    void Insert(TEntity model);
    void Update(TEntity model);
    void Delete(int id);

    int Count();
    void Save();

  }
}
