using DataAccessLayer.Concrete;
using RecipesProject.CQRS.Commands.TeamCommands;

namespace RecipesProject.CQRS.Handlers.TeamHandlers
{
    public class DeleteTeamCommandHandler
    {
        private readonly Context _context;

        public DeleteTeamCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(DeleteTeamCommand c)
        {
            var findTeamPerson = _context.Teams.Find(c.id);
            _context.Teams.Remove(findTeamPerson);
            _context.SaveChanges();
        }
    }
}
