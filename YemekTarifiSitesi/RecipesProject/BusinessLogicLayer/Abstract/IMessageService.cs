using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        public List<Message> TGetListMessageBySenderUser(Expression<Func<Message, bool>> filter);
        public List<Message> TGetListMessageByReceiverUser(Expression<Func<Message, bool>> filter);
        public Message TGetMessageBySenderUser(int id);
        public Message TGetMessageByReceiverUser(int id);
    }
}
