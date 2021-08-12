using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> List();
        List<Content> GetList(string p);
        List<Content> GetListById(int id);
        List<Content> GetListByWriterId(int id);
        void Add(Content content);
        void Delete(Content content);
        Content GetById(int contentId);
        void Update(Content content);
    }
}
