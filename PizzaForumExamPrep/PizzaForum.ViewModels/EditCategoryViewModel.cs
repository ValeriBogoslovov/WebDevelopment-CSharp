namespace PizzaForum.ViewModels
{
    using System;
    using System.Net;

    public class EditCategoryViewModel
    {
        private string name;
        public LoggedInUsernameViewModel Username { get; set; }
        public string Name
        {
            get
            {
                return WebUtility.UrlDecode(this.name);
            }
            set
            {
                this.name = value;
            }
        }
        public int Id { get; set; }
    }
}
