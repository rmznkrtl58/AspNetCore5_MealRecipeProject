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
    public class EventManager : IEventService
    {
        IEventDal _eventDal;

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public void TAdd(Event t)
        {
            _eventDal.Insert(t);
        }

        public void TDelete(Event t)
        {
           _eventDal.Delete(t);
        }

        public Event TGetByCondition(Expression<Func<Event, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Event TGetById(int id)
        {
           return _eventDal.GetById(id);
        }

        public List<Event> TGetListAll()
        {
            return _eventDal.GetListAll();
        }

        public List<Event> TGetListAll(Expression<Func<Event, bool>> filter)
        {
            return _eventDal.GetListAll(filter);
        }

        public void TUpdate(Event t)
        {
            _eventDal.Update(t);
        }
    }
}
