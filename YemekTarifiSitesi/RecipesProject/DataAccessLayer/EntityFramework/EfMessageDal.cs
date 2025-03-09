using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.GenericRepository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetListMessageByReceiverUser(Expression<Func<Message, bool>> filter)
        {
            using (var ent = new Context())
            {
                return ent.Messages.Include(x => x.ReceiverUser).Where(filter).ToList();
            }
        }

        public List<Message> GetListMessageBySenderUser(Expression<Func<Message,bool>>filter)
        {
            using (var ent=new Context())
            {
                return ent.Messages.Include(x=>x.SenderUser).Where(filter).ToList();
            }
        }

        public Message GetMessageByReceiverUser(int id)
        {
            using (var ent = new Context())
            {
                return ent.Messages.Include(x => x.ReceiverUser).FirstOrDefault(x => x.MessageId == id);
            }
        }

        public Message GetMessageBySenderUser(int id)
        {
            using (var ent=new Context())
            {
                return ent.Messages.Include(x => x.SenderUser).FirstOrDefault(x => x.MessageId == id);
            }
        }
    }
}
