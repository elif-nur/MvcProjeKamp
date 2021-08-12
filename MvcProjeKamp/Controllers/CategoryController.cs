using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
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
            //_categoryManager.Add(category);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);//geçerliliğini kontrol eder.
            if (validationResult.IsValid) //sonuc uygunsa - geçerliyse
            {
                _categoryManager.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors) //hata mesajlarını tutan döngü
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //hatalı olan isim ve hata mesajı
                }
            }
            return View();
        }
    }
}