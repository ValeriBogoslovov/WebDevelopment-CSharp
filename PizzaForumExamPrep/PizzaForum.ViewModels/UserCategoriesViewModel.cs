namespace PizzaForum.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class UserCategoriesViewModel : CategoriesViewModel
    {
        public UserCategoriesViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
        }

        public override string ToString()
        {
            var categoriesHtml = string.Empty;
            categoriesHtml = (File.ReadAllText("../../content/admin-categories.html"));

            var replaceBuilder = new StringBuilder();

            foreach (var category in this.Categories)
            {
                replaceBuilder.AppendLine($"<tr><td><a href=\"/categories/all?id={category.Id}\">{category.Name}</a></td>");
            }

            return string.Format(categoriesHtml, string.Empty, string.Empty, replaceBuilder);
        }
    }
}
