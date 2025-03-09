using System.ComponentModel.DataAnnotations;

namespace RecipesProject.CQRS.Results.TeamResults
{
    public class GetAllTeamQueryResult
    {
        //Result->CQRS için listeleme ve belli bir Id'ye göre getirmek için 
        //read yapacağımız alandır ve burada neyi listeliceksen veya görmek istiyorsan
        //onun proplarını yazacaksın
        public int TeamId { get; set; }
        public string NameSurname { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
    }
}
