using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.GenericRepository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using (var ent=new Context())
            {
                ent.Set<T>().Remove(t);
                ent.SaveChanges();
            }
        }

        public T GetByCondition(Expression<Func<T, bool>> filter)
        {
            using (var ent=new Context())
            {
                return ent.Set<T>().Where(filter).FirstOrDefault();
            }
        }

        public T GetById(int id)
        {
            using (var ent = new Context())
            {
                return ent.Set<T>().Find(id);
            }
        }
        public List<T> GetListAll()
        {
            using (var ent=new Context())
            {
                return ent.Set<T>().ToList();
            }
        }
        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using (var ent=new Context())
            {
                return ent.Set<T>().Where(filter).ToList();
            }
        }
        public void Insert(T t)
        {
            using (var ent=new Context())
            {
                ent.Set<T>().Add(t);
                ent.SaveChanges();
            }
        }

        public void Update(T t)
        {
            using (var ent=new Context())
            {
                ent.Set<T>().Update(t);
                ent.SaveChanges();
            }
        }
    }
}
