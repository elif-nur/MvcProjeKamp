using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public Admin Find(string username, string password)
        {
            Context context = new Context();
            return context.Set<Admin>().Where(x => x.AdminUserName == username && x.AdminPassword == password).SingleOrDefault();
        }
    }
}
