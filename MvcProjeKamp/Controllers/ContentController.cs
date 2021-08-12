using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {
            if (!String.IsNullOrEmpty(p))
            {
                var value = _contentManager.GetList(p);
                return View(value);
            }
            else
            {
                var value = _contentManager.List();
                return View(value);
            }
           
            
        }
        public ActionResult ContentByHeading(int id) //içerikleri başlığa göre getir
        {
           var content= _contentManager.GetListById(id);
            return View(content);
        }
    }
}