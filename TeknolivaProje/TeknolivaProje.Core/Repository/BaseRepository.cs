using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TeknolivaProje.Core.Infrastructure;
using TeknolivaProje.Data.Models;

namespace TeknolivaProje.Core.Repository
{
  public abstract class BaseRepository<TEntity>:IRepository<TEntity> where TEntity:class
  {
    private readonly  ServiceDBContext _context = new ServiceDBContext();
    private readonly DbSet<TEntity> _dbSet;

    protected BaseRepository()
    {
      _dbSet = _context.Set<TEntity>();
    }

    #region Repository Metodlarının Yazımı

    

    public IEnumerable<TEntity> GetAll()
    {
      return _dbSet.ToList();
    }

    public TEntity GetById(int id)
    {

      return _dbSet.Find(id);
    }

    public TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
      return _dbSet.FirstOrDefault(expression);
    }

    public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression)
    {
      return _dbSet.Where(expression);
    }

    public void Insert(TEntity model)

    {
      _dbSet.Add(model);

    }

    public void Update(TEntity model)
    {
      _dbSet.Attach(model);
      _context.Entry(model).State=EntityState.Modified;
    }


    public void Delete(int id)
    {
      var data = GetById(id);
      _context.Entry(data).State=EntityState.Deleted;
    }

    public int Count()
    {
      return  _dbSet.Count();
    }

    public void Save()
    {
      _context.SaveChanges();
    }

    #endregion
  }
}
