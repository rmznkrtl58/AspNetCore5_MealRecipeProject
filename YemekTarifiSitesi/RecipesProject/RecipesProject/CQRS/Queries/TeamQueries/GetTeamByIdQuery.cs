namespace RecipesProject.CQRS.Queries.TeamQueries
{
    public class GetTeamByIdQuery
    {
        public GetTeamByIdQuery(int id)
        {
            this.id = id;
        }

        //query'ler neydi benim parametrelerimi tutacak yapıydı Id'ye göre listeleme
        //yapacağımdan dolayı Id'yi constructor içerisinde tanımlicam

        public int id { get; set; }
    }
}
