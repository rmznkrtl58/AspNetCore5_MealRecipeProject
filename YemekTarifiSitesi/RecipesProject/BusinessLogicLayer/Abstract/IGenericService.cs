using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IGenericService<T>where T : class
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetListAll();
        List<T> TGetListAll(Expression<Func<T,bool>>filter);
        T TGetById(int id);
        T TGetByCondition(Expression<Func<T,bool>>filter);
    }
}
