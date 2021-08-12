using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> List();
        List<Heading> GetListByWriter(int id); //yazara göre başlıkları listele
        List<Heading> GetListById(int id);
        void Add(Heading heading);
        void Delete(Heading heading);
        Heading GetById(int headindId);
        Heading GetId(int headindId);
        void Update(Heading heading);
       
    }
}
