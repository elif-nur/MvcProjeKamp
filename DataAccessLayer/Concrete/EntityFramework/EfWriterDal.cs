using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        //public Writer Find(string mail, string password)
        //{
        //    Context context = new Context();
        //    return context.Set<Writer>().Where(x => x.WriterMail == mail && x.WriterPassword == password).SingleOrDefault();
        //}

       
    }
}
