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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void Add(ImageFile imagefile)
        {
            throw new NotImplementedException();
        }

        public void Delete(ImageFile imagefile)
        {
            throw new NotImplementedException();
        }

        public ImageFile GetById(int imagefiletId)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetListById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> List()
        {
            return _imageFileDal.List();
        }

        public void Update(ImageFile imagefile)
        {
            throw new NotImplementedException();
        }
    }
}
