using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{   
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public Category TGetByCondition(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Category TGetById(int id)
        { 
            return _categoryDal.GetById(id);
        }

        public List<Category> TGetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public List<Category> TGetListAll(Expression<Func<Category, bool>> filter)
        {
           return _categoryDal.GetListAll(filter);
        }

        public void TUpdate(Category t)
        {
           _categoryDal.Update(t);
        }
    }
}
