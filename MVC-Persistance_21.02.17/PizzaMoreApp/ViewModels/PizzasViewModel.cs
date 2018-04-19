
namespace PizzaMoreApp.ViewModels
{
    public class PizzasViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Recipe { get; set; }
        public string ImageUrl { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
    }
}
