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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content GetById(int contentId)
        {
            return _contentDal.Get(x => x.ContentId == contentId);
        }

        public List<Content> GetList(string p)
        {
            return _contentDal.List(x=>x.ContentValue.Contains(p)); //parametreden gelen değeri içerip içermediği kontrol edilir.
        }

        public List<Content> GetListById(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetListByWriterId(int id)
        {
            return _contentDal.List(x=>x.WriterId==id);
        }

        public List<Content> List()
        {
            return _contentDal.List();
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
