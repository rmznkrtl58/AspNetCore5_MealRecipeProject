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
    public class WhyUsManager : IWhyUsService
    {
        IWhyUsDal _whyUsDal;

        public WhyUsManager(IWhyUsDal whyUsDal)
        {
            _whyUsDal = whyUsDal;
        }

        public void TAdd(WhyUs t)
        {
            _whyUsDal.Insert(t);
        }

        public void TDelete(WhyUs t)
        {
            _whyUsDal.Delete(t);
        }

        public WhyUs TGetByCondition(Expression<Func<WhyUs, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public WhyUs TGetById(int id)
        {
          return _whyUsDal.GetById(id);
        }

        public List<WhyUs> TGetListAll()
        {
           return _whyUsDal.GetListAll();
        }

        public List<WhyUs> TGetListAll(Expression<Func<WhyUs, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WhyUs t)
        {
            _whyUsDal.Update(t);
        }
    }
}
