

namespace PizzaForum.ViewModels
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class CategoriesViewModel
    {
        public string LoggedUserName { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
