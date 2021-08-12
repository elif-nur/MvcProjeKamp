using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.FluentValidation;
using FluentValidation.Results;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        Context _context = new Context();
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            ViewBag.d = p;
            id = _context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var list = _writerManager.GetById(id);
            ViewBag.a = id;
            return View(list);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator rules = new WriterValidator();
            ValidationResult validation = rules.Validate(writer);
            if (validation.IsValid)
            {
                _writerManager.Update(writer);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var item in validation.Errors)
                {
                   ModelState.AddModelError(item.PropertyName , item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writerid = _context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var deger = _headingManager.GetListByWriter(writerid);
            return View(deger);
        }
        public ActionResult CreateHeading()
        {
           
            var category = (from i in _categoryManager.List()
                            select new SelectListItem
                            {
                                Text = i.CategoryName,
                                Value = i.CategoryId.ToString()
                            }
                          ).ToList();
            ViewBag.category = category;

            return View();
        }
        [HttpPost]
        public ActionResult CreateHeading(Heading heading)
        {
            string value = (string)Session["WriterMail"];
            var writerid = _context.Writers.Where(x => x.WriterMail == value).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerid;
            heading.HeadingStatus = true;
            _headingManager.Add(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult EditHeading(int id)
        {
            var category = (from i in _categoryManager.List()
                            select new SelectListItem
                            {
                                Text = i.CategoryName,
                                Value = i.CategoryId.ToString()
                            }
                          ).ToList();
            ViewBag.category = category;

            var deger = _headingManager.GetById(id);
            return View("EditHeading", deger);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            _headingManager.Update(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult Delete(int id)
        {
            var status = _headingManager.GetById(id);
            if (status.HeadingStatus == true)
            {
                status.HeadingStatus = false;
            }
            else
            {
                status.HeadingStatus = true;
            }
            _headingManager.Delete(status);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p=1)
        {
            var list = _headingManager.List().ToPagedList(p,4);
            return View(list);
        }
    }
}