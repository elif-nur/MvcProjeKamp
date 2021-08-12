using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        public ActionResult Index()
        {
            var list = _writerManager.List();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);

            if (result.IsValid)
            {
                _writerManager.Add(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
        public ActionResult Bring(int id)
        {
            var deger = _writerManager.GetById(id);
            return View("Bring", deger);
        }
        [HttpPost]
        public ActionResult Update(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(writer);

            if (result.IsValid)
            {
                _writerManager.Update(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View("Bring");
          
        }
        public ActionResult Delete(int id)
        {
            var deleted = _writerManager.GetById(id);
            _writerManager.Delete(deleted);
            return RedirectToAction("Index");
        }
        public ActionResult Heading(int id)
        {
            var list = _headingManager.GetListByWriter(id);
            return View(list);
        }
    }
}