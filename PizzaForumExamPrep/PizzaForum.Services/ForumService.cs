namespace PizzaForum.Services
{
    using BindingModels;
    using Models;
    using SimpleHttpServer.Models;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ForumService : Service
    {
        public bool IsEnteredCredentialsValid(RegisterUserBindingModel model)
        {
            var usernameRegex = new Regex("[a-z0-9]{3,}");
            var passwordkRegex = new Regex("[0-9]{4}");
            if (!usernameRegex.IsMatch(model.Username))
            {
                return false;
            }
            if (!model.Email.Contains("@"))
            {
                return false;
            }
            if (!passwordkRegex.IsMatch(model.Password) || model.Password != model.ConfirmPassword)
            {
                return false;
            }
            if (this.Context.Users.Any(u => u.Username == model.Username || u.Email == model.Email))
            {
                return false;
            }
            return true;
        }
        public void RegisterUserToDb(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password
            };
            if (!this.Context.Users.Any())
            {
                user.IsAdmin = true;
            }

            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }
        public bool IsUserValid(LoginUserBindingModel model)
        {
            if (this.Context.Users.Any(u => (u.Username == model.UsernameOrEmail ||
                u.Email == model.UsernameOrEmail) && u.Password == model.Password))
            {
                return true;
            }
            return false;
        }

        public void LoginUser(LoginUserBindingModel model, HttpSession session)
        {
            this.Context.Logins.Add(new Login()
            {
                SessionId = session.Id,
                IsActive = true,
                User = this.Context.Users.FirstOrDefault(u => (u.Username == model.UsernameOrEmail ||
                    u.Email == model.UsernameOrEmail) && u.Password == model.Password)
            });

            this.Context.SaveChanges();
        }
    }
}
