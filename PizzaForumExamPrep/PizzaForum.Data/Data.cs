
namespace PizzaForum.Data
{
    public class Data
    {
        private static PizzaForumDbContext context;

        public static PizzaForumDbContext Context => context ?? (context = new PizzaForumDbContext());
    }
}
