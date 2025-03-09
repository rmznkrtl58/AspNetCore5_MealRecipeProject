using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMealDal : IGenericDal<Meal>
    {
        public List<Meal> GetListMealWithCategory(Expression<Func<Meal,bool>>filter);
        public List<Meal> GetListLast8Meal();
    }
}
