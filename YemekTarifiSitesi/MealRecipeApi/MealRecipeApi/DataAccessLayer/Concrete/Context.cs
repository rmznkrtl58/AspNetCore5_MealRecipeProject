using MealRecipeApi.EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace MealRecipeApi.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VM4NR9R\\SQLEXPRESS;database=MealRecipeApiDb;integrated security=true");
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
