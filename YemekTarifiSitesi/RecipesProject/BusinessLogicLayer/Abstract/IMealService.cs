using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IMealService : IGenericService<Meal>
    {
        public List<Meal> TGetListMealWithCategory(Expression<Func<Meal,bool>> filter);
        public List<Meal> TGetListLast8Meal();
    }
}

