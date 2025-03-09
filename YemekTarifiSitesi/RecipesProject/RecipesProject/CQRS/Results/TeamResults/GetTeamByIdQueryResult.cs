using System.ComponentModel.DataAnnotations;

namespace RecipesProject.CQRS.Results.TeamResults
{
    public class GetTeamByIdQueryResult
    {
        //güncellemek isteyeceğim verileri getircem
        public int TeamId { get; set; }
        public string NameSurname { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public string LinkedinUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
    }
}
