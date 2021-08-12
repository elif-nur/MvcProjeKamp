using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var list = _headingManager.List();
            return View(list);
        }
        public PartialViewResult Index(int id=0)
        {
         
            var contentlist = _contentManager.GetListById(id);
            return PartialView(contentlist);
        }
    }
}