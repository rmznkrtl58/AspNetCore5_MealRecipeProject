using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesProject.CQRS.Commands.TeamCommands;
using RecipesProject.CQRS.Handlers.TeamHandlers;
using RecipesProject.CQRS.Queries.TeamQueries;

namespace RecipesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class TeamController : Controller
    {   //CQRS DESİGN PATTERN UYGULAMASI
        private readonly GetAllTeamQueryHandler _getAllTeamHandler;
        private readonly CreateTeamCommandHandler _createTeamCommandHandler;
        private readonly GetTeamByIdQueryHandler _GetTeamByIdHandler;
        private readonly UpdateTeamCommandHandler _updateTeamHandler;
        private readonly DeleteTeamCommandHandler _deleteTeamdHandler;


        public TeamController(GetAllTeamQueryHandler getAllTeamHandler, CreateTeamCommandHandler createTeamCommandHandler, GetTeamByIdQueryHandler getTeamByIdHandler, UpdateTeamCommandHandler updateTeamHandler, DeleteTeamCommandHandler deleteTeamdHandler)
        {
            _getAllTeamHandler = getAllTeamHandler;
            _createTeamCommandHandler = createTeamCommandHandler;
            _GetTeamByIdHandler = getTeamByIdHandler;
            _updateTeamHandler = updateTeamHandler;
            _deleteTeamdHandler = deleteTeamdHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllTeamHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(CreateTeamCommand c)
        {
            _createTeamCommandHandler.Handle(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var findTeamPerson = _GetTeamByIdHandler.Handle(new GetTeamByIdQuery(id));
            return View (findTeamPerson);
        }
        [HttpPost]
        public IActionResult EditTeam(UpdateTeamCommand c)
        {
            _updateTeamHandler.Handle(c);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTeam(int id)
        {
            _deleteTeamdHandler.Handle(new DeleteTeamCommand(id));
            return RedirectToAction("Index");
        }

    }
}
