using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public Writer Find(string mail, string password)
        {
            return _writerDal.Get(x => x.WriterMail == mail && x.WriterPassword == password);
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

       

        public List<Writer> List()
        {
            return _writerDal.List();
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }

     
    }
}
