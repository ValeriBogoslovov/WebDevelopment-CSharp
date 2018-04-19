namespace PizzaMore.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaMoreDbContext : DbContext
    {
        public PizzaMoreDbContext()
            : base("PizzaMoreDbContext")
        {
        }

        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    }
}