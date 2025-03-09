namespace RecipesProject.CQRS.Commands.TeamCommands
{
    public class CreateTeamCommand
    {
        //Command->create-delete-update'leri kapsar burada takımımıza eklemek istediğim
        //propları yazacağım
        public string NameSurname { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public string LinkedinUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }

    }
}
