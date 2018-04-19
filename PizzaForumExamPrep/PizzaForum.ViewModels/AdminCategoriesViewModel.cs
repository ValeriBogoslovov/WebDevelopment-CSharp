namespace PizzaForum.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class AdminCategoriesViewModel : CategoriesViewModel
    {
        public AdminCategoriesViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
        }

        public override string ToString()
        {
            var categoriesHtml = string.Empty;
            var newCategoryButton = "<a href=\"/categories/new\" class=\"btn btn-success\">New Category</a>";
            categoriesHtml = (File.ReadAllText("../../content/admin-categories.html"));

            var replaceBuilder = new StringBuilder();
            var editDeleteColumn = "<th>Edit</th><th>Delete</th>";

            foreach (var category in this.Categories)
            {
                replaceBuilder.AppendLine($"<tr><td><a href=\"/categories/all?id={category.Id}\">{category.Name}</a></td>");
                replaceBuilder.AppendLine($"<td><a href=\"/categories/edit?id={category.Id}&name={category.Name}\" class=\"btn btn-primary\">Edit</a></td>");
                replaceBuilder.AppendLine($"<td><button class=\"btn btn-danger\" name=\"id\" value=\"{category.Id}\">Delete</button></td></tr>");
            }

            return string.Format(categoriesHtml, newCategoryButton, editDeleteColumn, replaceBuilder);
        }
    }
}
