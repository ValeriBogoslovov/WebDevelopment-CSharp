namespace PizzaForum.Services
{
    using Data;
    public abstract class Service
    {
        public Service()
        {
            this.Context = Data.Context;
        }
        protected PizzaForumDbContext Context { get; }
    }
}
