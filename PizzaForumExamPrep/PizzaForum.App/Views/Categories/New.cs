namespace PizzaForum.App.Views.Categories
{
    using Constants;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class New : IRenderable<LoggedInUsernameViewModel>
    {
        public LoggedInUsernameViewModel Model { get; set; }
        public string Render()
        {
            var sb = new StringBuilder();

            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.Header));
            sb.Append(string.Format(File.ReadAllText(Constanza.ContentPath + Constanza.NavLogged), Model.Username));
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.CategoriesNew));
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.Footer));

            return sb.ToString();
        }
    }
}
