namespace RecipesProject.CQRS.Commands.TeamCommands
{
    public class UpdateTeamCommand
    {
        //GetTeamByIdQuery Resultta güncellemek istediğim propları yazarak
        //sayfamda o takımın bilgilerini getirdim ordaki propları aynen buraya yazıyorum
        //çünkü güncelleme yapacağım proplar olduğu için
        public int TeamId { get; set; }
        public string NameSurname { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public string LinkedinUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
    }
}
