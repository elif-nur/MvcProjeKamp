using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        Context _context = new Context();
        public ActionResult MyContent(string p)
        { 
            p = (string)Session["WriterMail"];
            var writeridinfo = _context.Writers.Where(x => x.WriterMail == p).Select(y=>y.WriterId).FirstOrDefault(); //sisteme giriş yapan kullanıcının id değeri alındı.
            var list = _contentManager.GetListByWriterId(writeridinfo);
            return View(list);
        }
        public ActionResult AddContent(int id)
        {
            ViewBag.value = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = _context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writeridinfo;
            content.ContentStatus = true;
            _contentManager.Add(content);
            return RedirectToAction("MyContent");
        }
       
    }
}