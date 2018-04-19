namespace PizzaForum.App.Views.Categories
{
    using System;
    using SimpleMVC.Interfaces;
    using System.Text;
    using System.IO;
    using Constants;
    using ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class All : IRenderable<CategoriesViewModel>
    {
        public CategoriesViewModel Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();

            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.Header));
            sb.Append(string.Format(File.ReadAllText(Constanza.ContentPath + Constanza.NavLogged), 
                Model.LoggedUserName));
            sb.Append(Model.ToString());
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.Footer));

            return sb.ToString();
        }
    }
}
