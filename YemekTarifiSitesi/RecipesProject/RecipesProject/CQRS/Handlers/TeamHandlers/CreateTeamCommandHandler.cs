using DataAccessLayer.Concrete;
using RecipesProject.CQRS.Commands.TeamCommands;
using EntityLayer.Concrete;

namespace RecipesProject.CQRS.Handlers.TeamHandlers
{
    public class CreateTeamCommandHandler
    {
        private readonly Context _context;

        public CreateTeamCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(CreateTeamCommand c)
        {
            _context.Teams.Add(new Team
            {
                DeleteStatus=true,
                Image=c.Image,
                NameSurname=c.NameSurname,
               InstagramUrl=c.InstagramUrl,
               LinkedinUrl=c.LinkedinUrl,
               TwitterUrl=c.TwitterUrl,
               Status=c.Status,
            });
            _context.SaveChanges();
        }
    }
}
