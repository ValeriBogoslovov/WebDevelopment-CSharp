

namespace PizzaMoreApp.Views.Home
{
    using System;
    using SimpleMVC.Interfaces;
    using System.IO;

    public class Signup : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/signup.html");
        }
    }
}
