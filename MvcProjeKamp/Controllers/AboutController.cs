using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        // GET: About

        AboutManager _aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(About about)
        {
            _aboutManager.Add(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutList()
        {
            var model = _aboutManager.List();
            return PartialView(model);
        }
      
    }
}