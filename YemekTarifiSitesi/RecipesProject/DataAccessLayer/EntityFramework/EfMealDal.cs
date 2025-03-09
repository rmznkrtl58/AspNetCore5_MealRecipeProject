using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.GenericRepository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMealDal : GenericRepository<Meal>, IMealDal
    {
        public List<Meal> GetListLast8Meal()
        {
            using (var ent =new Context())
            {
                return ent.Meals.OrderByDescending(x => x.MealId).Take(8).ToList();
            }
        }
        public List<Meal> GetListMealWithCategory(Expression<Func<Meal, bool>> filter)
        {
            using (var ent=new Context())
            {
                return ent.Meals.Include(x=>x.Category).Where(filter).ToList();
            }
        }
    }
}
