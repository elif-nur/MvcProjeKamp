using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public void Remove(Message message)
        {
            Context context = new Context();
            var deleted = context.Entry(message);
            deleted.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
