using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager _adminManager = new AdminManager(new EfAdminDal());
        WriterManager _writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            var adminuserinfo = _adminManager.Find(admin.AdminUserName, admin.AdminPassword);
          
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName; //sisteme giren kişinin bilgileri buradan gelecek.
                return RedirectToAction("Index", "AdminCategory");
            }
           
            else
            {
                ViewBag.mesaj = "Kullanıcı adı ya da şifre hatalı";
                return RedirectToAction("Index");
            }
            
        }
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var writeruserinfo = _writerManager.Find(writer.WriterMail,writer.WriterPassword);

            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail; //sisteme giren kişinin bilgileri buradan gelecek.
                return RedirectToAction("MyContent", "WriterPanelContent");
            }

            else
            {
                ViewBag.mesaj = "Kullanıcı adı ya da şifre hatalı";
                return RedirectToAction("WriterLogin");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}