using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> List();
        List<ImageFile> GetListById(int id);
        void Add(ImageFile imagefile);
        void Delete(ImageFile imagefile);
        ImageFile GetById(int imagefiletId);
        void Update(ImageFile imagefile);
    }
}
