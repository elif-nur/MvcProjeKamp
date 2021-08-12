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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());

        //[Authorize(Roles ="B")]
        public ActionResult Index()
        {
            var list = _categoryManager.List();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            CategoryValidator validations = new CategoryValidator();
            ValidationResult validationResult = validations.Validate(category);
            if (validationResult.IsValid)
            {
                _categoryManager.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var deleted=_categoryManager.GetById(id);
            _categoryManager.Delete(deleted);
            return RedirectToAction("Index");
        }
        public ActionResult Bring(int id)
        {
            var updated = _categoryManager.GetById(id);
            return View("Bring", updated);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult rules = validationRules.Validate(category);
            if (rules.IsValid)
            {
                _categoryManager.Update(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in rules.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("Bring");
           
        }
        public ActionResult Heading(int id)
        {
            var model = _headingManager.GetListById(id);
           
            return View(model);
        }
    }
}