using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
        public List<Message> GetListMessageBySenderUser(Expression<Func<Message,bool>>filter);
        public List<Message> GetListMessageByReceiverUser(Expression<Func<Message,bool>>filter);
        public Message GetMessageBySenderUser(int id);
        public Message GetMessageByReceiverUser(int id);
    }
}
