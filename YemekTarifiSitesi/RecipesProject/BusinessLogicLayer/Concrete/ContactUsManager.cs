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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void TAdd(ContactUs t)
        {
            _contactUsDal.Insert(t);
        }

        public void TDelete(ContactUs t)
        {
            throw new NotImplementedException();
        }

        public ContactUs TGetByCondition(Expression<Func<ContactUs, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public ContactUs TGetById(int id)
        {
           return _contactUsDal.GetById(id);
        }

        public List<ContactUs> TGetListAll()
        {
          return _contactUsDal.GetListAll();
        }

        public List<ContactUs> TGetListAll(Expression<Func<ContactUs, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ContactUs t)
        {
            throw new NotImplementedException();
        }
    }
}
