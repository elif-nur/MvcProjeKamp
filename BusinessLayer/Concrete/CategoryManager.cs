using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category category) {_categoryDal.Add(category);}
        public void Delete(Category category) { _categoryDal.Delete(category);}

    

        public Category GetById(int categoryId) { return _categoryDal.Get(x => x.CategoryId == categoryId);}
        public List<Category> List() { return _categoryDal.List(); }
        public void Update(Category category) {  _categoryDal.Update(category);}
    }
}
