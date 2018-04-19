namespace PizzaForum.App.Controllers
{
    using BindingModels;
    using Models;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class CategoriesController : Controller
    {
        private CategoriesService service;
        private UserService userService;
        public CategoriesController()
        {
            this.service = new CategoriesService();
            this.userService = new UserService();
        }
        [HttpGet]
        public IActionResult<CategoriesViewModel> All(HttpSession session)
        {
            CategoriesViewModel viewModel = null;
            var user = userService.GetActiveUser(session);

            if (userService.IsUserAdmin(user))
            {
                viewModel = new AdminCategoriesViewModel();
            }
            else
            {
                viewModel = new UserCategoriesViewModel();
            }
            viewModel.LoggedUserName = user.Username;
            viewModel.Categories = service.GetCategories();

            return this.View(viewModel);
        }
        [HttpGet]
        public IActionResult<LoggedInUsernameViewModel> New(HttpSession session)
        {
            LoggedInUsernameViewModel username = new LoggedInUsernameViewModel();
            username.Username = userService.GetActiveUser(session).Username;
            return this.View(username);
        }
        [HttpPost]
        public IActionResult New(EditCategoryBindingModel model, HttpResponse response)
        {
            this.service.AddNewCategory(model);
            this.Redirect(response, "/categories/all");
            return null;
        }
        [HttpGet]
        public IActionResult<EditCategoryViewModel> Edit(HttpSession session, int id, string name)
        {
            var user = userService.GetActiveUser(session);

            var viewModel = new EditCategoryViewModel()
            {
                Id = id,
                Name = name,
                Username = new LoggedInUsernameViewModel()
                {
                    Username = user.Username
                }
            };

            return this.View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditCategoryBindingModel model, HttpResponse response)
        {
            this.service.EditCategory(model);
            this.Redirect(response, "/categories/all");
            return null;
        }
        [HttpPost]
        public IActionResult Delete(DeleteCategoryBindingModel model, HttpResponse response)
        {
            this.service.DeleteCategory(model);
            this.Redirect(response, "/categories/all");
            return null;
        }
    }
}
