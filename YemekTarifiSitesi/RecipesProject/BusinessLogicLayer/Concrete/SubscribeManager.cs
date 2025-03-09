using BusinessLogicLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        public void TAdd(SubscribeMail t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(SubscribeMail t)
        {
            throw new NotImplementedException();
        }

        public SubscribeMail TGetByCondition(Expression<Func<SubscribeMail, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public SubscribeMail TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubscribeMail> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public List<SubscribeMail> TGetListAll(Expression<Func<SubscribeMail, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SubscribeMail t)
        {
            throw new NotImplementedException();
        }
    }
}
