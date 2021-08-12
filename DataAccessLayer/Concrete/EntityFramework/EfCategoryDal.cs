using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>,ICategoryDal
    {
        //Context context = new Context();
        //DbSet<Category> _object;
        //public void Add(Category category)
        //{
        //    _object.Add(category);
        //    context.SaveChanges();
        //    //using(Context context=new Context())
        //    //{
        //    //    var added = context.Entry(category);
        //    //    added.State = EntityState.Added;
        //    //    context.SaveChanges();
        //    //}
           
        //}

        //public void Delete(Category category)
        //{
        //    _object.Remove(category);
        //    context.SaveChanges();
        //    //using(Context context=new Context())
        //    //{
        //    //    var deleted = context.Entry(category);
        //    //    deleted.State = EntityState.Deleted;
        //    //    context.SaveChanges();
        //    //}
        //}

        //public Category Get(Expression<Func<Category, bool>> filter)
        //{
        //    return context.Set<Category>().FirstOrDefault(filter);
        //}

        //public List<Category> List(Expression<Func<Category, bool>> filter = null)
        //{
        //    return filter == null ? context.Set<Category>().ToList() : context.Set<Category>().Where(filter).ToList();
        //}

        //public void Update(Category category)
        //{
        //    context.SaveChanges();
        //    //using(Context context=new Context())
        //    //{
        //    //    var updated = context.Entry(category);
        //    //    updated.State = EntityState.Modified;
        //    //    context.SaveChanges();
        //    //}
        //}
    }
}
