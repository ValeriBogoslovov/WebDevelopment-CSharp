

namespace PizzaMoreApp.Controllers
{
    using BindingModels;
    using PizzaMore.Data;
    using PizzaMore.Models;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(HttpRequest request, HttpResponse response)
        {
            if (request.Header.Cookies.Contains("lang") && request.Header.Cookies["lang"].Value == "DE")
            {
                Redirect(response, "/home/indexde");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Indexde(HttpRequest request, HttpResponse response)
        {
            if (request.Header.Cookies.Contains("lang") && request.Header.Cookies["lang"].Value == "EN")
            {
                Redirect(response, "/home/index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Language(HttpResponse response, string language)
        {
            LanguageService.SetLanguange(response, language);
            if (response.Header.Cookies["lang"].Value == "EN")
            {
                Redirect(response, "/home/index");
            }
            else
            {
                Redirect(response, "/home/indexde");
            }
            return null;
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(HttpResponse response, UserBindingModel model)
        {
            UserService.SignUp(model);

            if (UserService.Exists())
            {
                return View();
            }
            else
            {
                Redirect(response, "/home/index");
            }
            return null;
        }
        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signin(HttpSession session, HttpResponse response,
            UserBindingModel model)
        {
            UserService.SignIn(model, session);
            if (UserService.Exists())
            {
                Redirect(response, "/home/index");
            }
            else
            {
                Redirect(response, "/home/signup");
            }
            return null;
        }
        [HttpGet]
        public IActionResult<IEnumerable<PizzasViewModel>> Menu(HttpSession session, HttpResponse response)
        {
            IEnumerable<PizzasViewModel> viewModel;
            using (var context = new PizzaMoreDbContext())
            {
                viewModel = new List<PizzasViewModel>(context.Pizzas.Select(p => new PizzasViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Recipe = p.Recipe,
                    ImageUrl = p.ImageUrl,
                    UpVotes = p.UpVotes,
                    DownVotes = p.DownVotes
                }));

                if (UserService.HasSignedIn(session))
                {
                    return View(viewModel);
                }
                else
                {
                    Redirect(response, "/home/signin");
                }
            }
            return null;   
        }
        [HttpPost]
        public IActionResult Menu(VoteBindingModel model, HttpResponse response)
        {
            UserService.Vote(model);
            Redirect(response, "/home/menu");
            return null;
        }
        [HttpGet]
        public IActionResult Signout(HttpResponse response, HttpSession session)
        {
            UserService.SignOut(session);
            Redirect(response, "/home/index");
            return null;
        }
    }
}
