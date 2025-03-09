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
    public class MealManager : IMealService
    {   
        IMealDal _mealDal;
        public MealManager(IMealDal mealDal)
        {
            _mealDal = mealDal;
        }
        public void TAdd(Meal t)
        {
            _mealDal.Insert(t);
        }

        public void TDelete(Meal t)
        {
            _mealDal.Delete(t);
        }

        public Meal TGetByCondition(Expression<Func<Meal, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Meal TGetById(int id)
        {
            return _mealDal.GetById(id);
        }

        public List<Meal> TGetListAll()
        {
            return _mealDal.GetListAll();
        }

        public List<Meal> TGetListAll(Expression<Func<Meal, bool>> filter)
        {
            return _mealDal.GetListMealWithCategory(filter);
        }

        public List<Meal> TGetListLast8Meal()
        {
            return _mealDal.GetListLast8Meal();
        }

        public List<Meal> TGetListMealWithCategory(Expression<Func<Meal,bool>>filter)
        {
            return _mealDal.GetListMealWithCategory(filter);
        }

        public void TUpdate(Meal t)
        {
            _mealDal.Update(t);
        }
    }
}
