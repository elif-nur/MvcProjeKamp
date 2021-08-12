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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public void Delete(Heading heading)
        {
           
            _headingDal.Update(heading);
        }

        public Heading GetById(int headindId)
        {
            return _headingDal.Get(x => x.HeadingId == headindId);
        }

        public Heading GetId(int headindId)
        {
            throw new NotImplementedException();
        }

        public List<Heading> GetListById(int id)
        {
            return _headingDal.List(x => x.CategoryId == id);
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterId == id);
        }

        public List<Heading> List()
        {
            return _headingDal.List();
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
