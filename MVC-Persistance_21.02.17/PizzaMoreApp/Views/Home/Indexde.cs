

namespace PizzaMoreApp.Views.Home
{
    using System;
    using SimpleMVC.Interfaces;
    using System.IO;

    public class Indexde : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/home-de.html");
        }
    }
}
