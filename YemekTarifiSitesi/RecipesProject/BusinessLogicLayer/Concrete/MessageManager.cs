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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TAdd(Message t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDal.Delete(t);
        }

        public Message TGetByCondition(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Message TGetById(int id)
        {
           return _messageDal.GetById(id);
        }

        public List<Message> TGetListAll()
        {
            return _messageDal.GetListAll();
        }

        public List<Message> TGetListAll(Expression<Func<Message, bool>> filter)
        {
           return _messageDal.GetListAll(filter);
        }

        public List<Message> TGetListMessageByReceiverUser(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.GetListMessageByReceiverUser(filter);
        }

        public List<Message> TGetListMessageBySenderUser(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.GetListMessageBySenderUser(filter);
        }

        public Message TGetMessageByReceiverUser(int id)
        {
            return _messageDal.GetMessageByReceiverUser(id);
        }

        public Message TGetMessageBySenderUser(int id)
        {
            return _messageDal.GetMessageBySenderUser(id);
        }

        public void TUpdate(Message t)
        {
            _messageDal.Update(t);
        }
    }
}
