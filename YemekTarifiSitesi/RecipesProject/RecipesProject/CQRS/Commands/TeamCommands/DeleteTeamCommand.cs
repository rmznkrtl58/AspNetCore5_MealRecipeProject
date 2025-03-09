namespace RecipesProject.CQRS.Commands.TeamCommands
{
    public class DeleteTeamCommand
    {    //silme işleminde id değeri gerekli olduğundan constructor içerisinde tanımladım
        public DeleteTeamCommand(int id)
        {
            this.id = id;
        }

        public int id {  get; set; }
    }
}
