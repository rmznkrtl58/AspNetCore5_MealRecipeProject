using DataAccessLayer.Concrete;
using RecipesProject.CQRS.Commands.TeamCommands;

namespace RecipesProject.CQRS.Handlers.TeamHandlers
{
    public class UpdateTeamCommandHandler
    {
        private readonly Context _context;

        public UpdateTeamCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateTeamCommand c)
        {
            var findTeamPerson = _context.Teams.Find(c.TeamId);
            findTeamPerson.DeleteStatus = true;
            findTeamPerson.Status = c.Status;
            findTeamPerson.NameSurname = c.NameSurname;
            findTeamPerson.InstagramUrl = c.InstagramUrl;
            findTeamPerson.TwitterUrl= c.TwitterUrl;
            findTeamPerson.LinkedinUrl = c.LinkedinUrl;
            findTeamPerson.Image = c.Image;
            _context.Teams.Update(findTeamPerson);
            _context.SaveChanges();
        }
    }
}
