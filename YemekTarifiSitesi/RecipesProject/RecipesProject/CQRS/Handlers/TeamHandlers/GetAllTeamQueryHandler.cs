using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using RecipesProject.CQRS.Results.TeamResults;
using System.Collections.Generic;
using System.Linq;

namespace RecipesProject.CQRS.Handlers.TeamHandlers
{
    public class GetAllTeamQueryHandler
    {
        //CQRS handler->Yapıcağım işlemleri tuttuğum yer yani crud işlemlerini
        //tutucağım yer
        private readonly Context _context;

        public GetAllTeamQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetAllTeamQueryResult> Handle()
        {
            var values= _context.Teams.Select(x => new GetAllTeamQueryResult
            {
                Image = x.Image,
                NameSurname = x.NameSurname,
                Status = x.Status,
                TeamId = x.TeamId
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
