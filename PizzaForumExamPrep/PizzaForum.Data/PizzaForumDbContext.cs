namespace PizzaForum.Data
{
    using Models;
    using System.Data.Entity;

    public class PizzaForumDbContext : DbContext
    {
        public PizzaForumDbContext()
            : base("PizzaForumDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}