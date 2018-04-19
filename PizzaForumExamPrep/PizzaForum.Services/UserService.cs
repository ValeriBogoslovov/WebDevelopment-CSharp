namespace PizzaForum.Services
{
    using Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;
    using System;
    using System.Linq;

    public class UserService : Service
    {
        public User GetActiveUser(HttpSession session)
        {
            var login = this.Context.Logins.FirstOrDefault(l => l.SessionId == session.Id && l.IsActive == true);
            var user = this.Context.Users.FirstOrDefault(u => u.Id == login.UserId);

            return user;
        }

        public bool IsUserAdmin(User user)
        {
            return user.IsAdmin;
        }

        public void Logout(HttpSession session, HttpResponse response)
        {
            this.Context.Logins.FirstOrDefault(l => l.SessionId == session.Id && l.IsActive == true).IsActive = false;
            this.Context.SaveChanges();
            var newSession = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", newSession.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
