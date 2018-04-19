

namespace PizzaForum.App.Views.Forum
{
    using System;
    using SimpleMVC.Interfaces;
    using System.Text;
    using Constants;
    using System.IO;

    public class Register : IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.Header));
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.NavNotLogged));
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.Register));
            sb.Append(File.ReadAllText(Constanza.ContentPath + Constanza.Footer));
            return sb.ToString();
        }
    }
}
