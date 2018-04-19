

namespace PizzaMoreApp.Services
{
    using BindingModels;
    using PizzaMore.Data;
    using PizzaMore.Models;
    using SimpleHttpServer.Models;
    using System.Linq;
    using System;

    public static class UserService
    {
        private static bool exists;
        public static void SignUp(UserBindingModel model)
        {
            var user = new User()
            {
                Email = model.Email,
                Password = model.Password
            };

            using (var context = new PizzaMoreDbContext())
            {
                if (context.Users.Any(u => u.Email == user.Email))
                {
                    exists = true;
                }
                else
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    exists = false;
                }
            }
        }
        public static void SignIn(UserBindingModel model, HttpSession session)
        {
            using (var context = new PizzaMoreDbContext())
            {
                var login = new Login()
                {
                    SessionId = session.Id,
                    IsActive = true,
                    User = context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password)
                };
                if (login.User == null)
                {
                    exists = false;
                }
                else
                {
                    context.Logins.Add(login);
                    context.SaveChanges();
                    exists = true;
                }
            }
        }
        public static void SignOut(HttpSession session)
        {
            using (var context = new PizzaMoreDbContext())
            {
                foreach (var login in context.Logins.Where(l=> l.IsActive == true && l.SessionId == session.Id))
                {
                    login.IsActive = false;
                }
                context.SaveChanges();
            }
        }
        public static void Vote(VoteBindingModel model)
        {
            using (var context = new PizzaMoreDbContext())
            {
                var pizzaToVote = context.Pizzas.Find(model.PizzaId);
                if (model.Vote == -1)
                {
                    pizzaToVote.DownVotes = model.Vote;
                }
                else
                {
                    pizzaToVote.UpVotes = model.Vote;
                }
                context.SaveChanges();
            }
        }
        public static bool HasSignedIn(HttpSession session)
        {
            using (var context = new PizzaMoreDbContext())
            {
                if (context.Logins.Any(l => l.SessionId == session.Id && l.IsActive == true))
                {
                    return true;
                }
                return false;
            }
        }
        public static bool Exists()
        {
            return exists;
        }
    }
}
