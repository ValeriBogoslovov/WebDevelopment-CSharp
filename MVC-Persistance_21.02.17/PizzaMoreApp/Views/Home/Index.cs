

namespace PizzaMoreApp.Views.Home
{
    using System;
    using SimpleMVC.Interfaces;
    using System.IO;

    public class Index : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home.html");
        }
    }
}
