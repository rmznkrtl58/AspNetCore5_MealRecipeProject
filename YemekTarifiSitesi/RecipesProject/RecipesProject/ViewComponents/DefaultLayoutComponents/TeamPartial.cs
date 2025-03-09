using AutoMapper;
using BusinessLogicLayer.Abstract;
using DTOLayer.DTOs.TeamDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesProject.ViewComponents.DefaultLayoutComponents
{
    public class TeamPartial:ViewComponent
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamPartial(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke() 
        {
            var values = _mapper.Map<List<TeamListDTO>>(_teamService.TGetListAll());
            return View(values); 
        }
    }
}
