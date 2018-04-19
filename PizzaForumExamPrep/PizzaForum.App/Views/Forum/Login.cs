namespace PizzaForum.App.Views.Forum
{
    using System;
    using SimpleMVC.Interfaces;
    using System.Text;
    using System.IO;
    using Constants;

    public class Login : IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.Header));
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.NavNotLogged));
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.Login));
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.Footer));

            return sb.ToString();
        }
    }
}
