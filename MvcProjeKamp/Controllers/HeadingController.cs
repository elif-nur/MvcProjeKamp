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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var list = _headingManager.List();
            return View(list);
        }
        public ActionResult HeadingReport()
        {
            var list = _headingManager.List();
            return View(list);
        }
        public ActionResult Create() //dropdownlist
        {
            List<SelectListItem> categoryvalue = (from i in _categoryManager.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryId.ToString()
                                                  }
                                                ).ToList() ;
            ViewBag.category = categoryvalue;

            List<SelectListItem> writervalue = (from i in _writerManager.List()
                                                select new SelectListItem
                                                {
                                                    Text = i.WriterName+" "+i.WriterSurName,
                                                    Value = i.WriterId.ToString()
                                                }
                                              ).ToList();
            ViewBag.writer = writervalue;

            return View();
        }
        [HttpPost]
        public ActionResult Create(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingManager.Add(heading);
            return RedirectToAction("Index");
        }
        public ActionResult Bring(int id) 
        {
            List<SelectListItem> category = (from i in _categoryManager.List()
                                             select new SelectListItem
                                             {
                                                 Text = i.CategoryName,
                                                 Value = i.CategoryId.ToString()
                                             }
                                           ).ToList();
            ViewBag.category = category;

            var deger=_headingManager.GetById(id);
            return View("Bring",deger);
        }
        [HttpPost]
        public ActionResult Update(Heading heading)
        {
            _headingManager.Update(heading);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var status = _headingManager.GetById(id);
            if(status.HeadingStatus==true)
            {
                status.HeadingStatus = false;
            }
            else
            {
                status.HeadingStatus = true;
            }
           
            _headingManager.Delete(status);
            return RedirectToAction("Index");
        }
    }
}