using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager _imageFileManager = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var model = _imageFileManager.List();
            return View(model);
        }
    }
}