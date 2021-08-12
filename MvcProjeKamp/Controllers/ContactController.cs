using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ContactManager _contactManager = new ContactManager(new EfContactDal());
        ContactValidator _validationRules = new ContactValidator();
    
        public ActionResult Index()
        {
            var model = _contactManager.List();
            return View(model);
        }
        public ActionResult ContactDetails(int id)
        {
            var deger = _contactManager.GetById(id);
            return View(deger);
        }
        public PartialViewResult Box()
        {
            return PartialView();
        }
    }
}