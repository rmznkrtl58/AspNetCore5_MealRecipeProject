using DataAccessLayer.Concrete;
using RecipesProject.CQRS.Queries.TeamQueries;
using RecipesProject.CQRS.Results.TeamResults;

namespace RecipesProject.CQRS.Handlers.TeamHandlers
{
    public class GetTeamByIdQueryHandler
    {
        private readonly Context _context;

        public GetTeamByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public GetTeamByIdQueryResult Handle(GetTeamByIdQuery query)
        {
            var findTeamPerson = _context.Teams.Find(query.id);
            return new GetTeamByIdQueryResult
            {
                Image = findTeamPerson.Image,
                TeamId = findTeamPerson.TeamId,
                InstagramUrl = findTeamPerson.InstagramUrl,
                LinkedinUrl = findTeamPerson.LinkedinUrl,
                NameSurname = findTeamPerson.NameSurname,
                Status = findTeamPerson.Status,
                TwitterUrl = findTeamPerson.TwitterUrl
            };
        }
    }
}
