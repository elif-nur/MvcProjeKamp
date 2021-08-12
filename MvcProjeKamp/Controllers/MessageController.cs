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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        MessageValidator _validationRules = new MessageValidator();
        public ActionResult Inbox(string p)
        {
           
            var model = _messageManager.GetListInBox(p);
            return View(model);
        }
        public ActionResult Sendbox(string p)
        {
            var model = _messageManager.GetListSendBox(p);
            return View(model);
        }
        public ActionResult AddMessage()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            ValidationResult result = _validationRules.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _messageManager.Add(message);
                return RedirectToAction("Sendbox");
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
        public ActionResult MessageInboxDetails(int id)
        {
            var deger = _messageManager.GetById(id);
            return View(deger);
        }
        public ActionResult MessageSendboxDetails(int id)
        {
            var deger = _messageManager.GetById(id);
            return View(deger);
        }
        public ActionResult Delete(int id)
        {
            var status = _messageManager.GetById(id);
            if (status.MessageStatus1 == true)
            {
                status.MessageStatus1 = false;
            }
            else
            {
                status.MessageStatus1 = true;
            }
            _messageManager.Delete(status);
            return RedirectToAction("Inbox");
        }

    }
}