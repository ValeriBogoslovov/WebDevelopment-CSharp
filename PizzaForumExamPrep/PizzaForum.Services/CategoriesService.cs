namespace PizzaForum.Services
{
    using ViewModels;
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using BindingModels;
    using Models;
    using SimpleHttpServer.Models;

    public class CategoriesService : Service
    {
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            return this.Context.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public void AddNewCategory(EditCategoryBindingModel model)
        {
            this.Context.Categories.Add(new Category()
            {
                Name = model.Name
            });
            this.Context.SaveChanges();
        }

        public void EditCategory(EditCategoryBindingModel model)
        {
            this.Context.Categories.FirstOrDefault(c => c.Id == model.Id).Name = model.Name;
            this.Context.SaveChanges();
        }

        public void DeleteCategory(DeleteCategoryBindingModel model)
        {
            var category = this.Context.Categories.FirstOrDefault(c => c.Id == model.Id);
            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();
        }
    }
}
