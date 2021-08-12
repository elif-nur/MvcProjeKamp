using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> List(Expression<Func<T,bool>>filter=null); //hepsini listele ya da filtreleyerek listele
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
