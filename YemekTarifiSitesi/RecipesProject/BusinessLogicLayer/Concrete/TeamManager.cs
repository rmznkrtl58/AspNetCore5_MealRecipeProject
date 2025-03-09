using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public void TAdd(EntityLayer.Concrete.Team t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(EntityLayer.Concrete.Team t)
        {
            throw new NotImplementedException();
        }

        public EntityLayer.Concrete.Team TGetByCondition(Expression<Func<EntityLayer.Concrete.Team, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public EntityLayer.Concrete.Team TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EntityLayer.Concrete.Team> TGetListAll()
        {
            return _teamDal.GetListAll();
        }

        public List<EntityLayer.Concrete.Team> TGetListAll(Expression<Func<EntityLayer.Concrete.Team, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(EntityLayer.Concrete.Team t)
        {
            throw new NotImplementedException();
        }
    }
}
