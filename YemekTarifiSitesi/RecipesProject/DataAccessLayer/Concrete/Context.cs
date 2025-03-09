using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VM4NR9R\\SQLEXPRESS;database=MealRecipeDb;integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>()
              .HasOne(x => x.SenderUser)
              .WithMany(x => x.SenderMessage)
              .HasForeignKey(x => x.SenderId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Message>()
              .HasOne(x => x.ReceiverUser)
              .WithMany(x => x.ReceiverMessage)
              .HasForeignKey(x => x.ReceiverId)
              .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(builder);

            //HasKey Id'nin hangisi olduğunu belirtir
            builder.Entity<AppUser>().HasKey(x => x.Id);
        }
        public DbSet<About>Abouts { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Contact>Contacts { get; set; }
        public DbSet<ContactUs>ContactUses { get; set; }
        public DbSet<Event>Events { get; set; }
        public DbSet<Meal>Meals { get; set; }
        public DbSet<SubscribeMail>SubscribeMails { get; set; }
        public DbSet<SuggestRecipe>SuggestRecipes { get; set; }
        public DbSet<Team>Teams { get; set; }
        public DbSet<Testimonial>Testimonials { get; set; }
        public DbSet<WhyUs>WhyUses{ get; set; }
        public DbSet<Message> Messages{ get; set; }
    }
}
