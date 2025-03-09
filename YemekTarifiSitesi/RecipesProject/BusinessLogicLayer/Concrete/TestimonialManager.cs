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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TAdd(Testimonial t)
        {
           _testimonialDal.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
          _testimonialDal.Delete(t);
        }

        public Testimonial TGetByCondition(Expression<Func<Testimonial, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Testimonial TGetById(int id)
        {
           return _testimonialDal.GetById(id);
        }

        public List<Testimonial> TGetListAll()
        {
           return _testimonialDal.GetListAll();
        }

        public List<Testimonial> TGetListAll(Expression<Func<Testimonial, bool>> filter)
        {
            return _testimonialDal.GetListAll(filter);
        }

        public void TUpdate(Testimonial t)
        {
             _testimonialDal.Update(t);
        }
    }
}
