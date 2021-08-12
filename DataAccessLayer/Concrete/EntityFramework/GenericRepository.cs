using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class GenericRepository<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        Context context = new Context();
        public void Add(T entity)
        {
            var added = context.Entry(entity);
            added.State = EntityState.Added;
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            var deleted = context.Entry(entity);
            deleted.State = EntityState.Deleted;
            context.SaveChanges();
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().FirstOrDefault(filter);
        }
        public List<T> List(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
        }
        public void Update(T entity)
        {
            var updated = context.Entry(entity);
            updated.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
