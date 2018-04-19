

namespace PizzaForum.App.Controllers
{
    using BindingModels;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    public class ForumController : Controller
    {
        private ForumService service;
        private UserService userService;
        public ForumController()
        {
            this.service = new ForumService();
            this.userService = new UserService();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel model)
        {
            if (!service.IsEnteredCredentialsValid(model))
            {
                this.Redirect(response, "/forum/register");
            }
            else
            {
                this.service.RegisterUserToDb(model);
                this.Redirect(response, "/forum/login");
            }
            return null;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model, HttpSession session, HttpResponse response)
        {
            if (this.service.IsUserValid(model))
            {
                this.service.LoginUser(model, session);
                this.Redirect(response, "/categories/all");
            }
            return null;
        }

        [HttpPost]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            this.userService.Logout(session, response);

            this.Redirect(response, "/forum/login");
            return null;
        }
    }
}
