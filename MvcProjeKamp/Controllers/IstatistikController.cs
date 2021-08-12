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
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var list = categoryManager.List();
            var deger = (from i in list
                         select i.CategoryName

                         
                         ).Count();
            ViewBag.deger = deger;

           
            return View();
        }
    }
}