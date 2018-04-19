

namespace PizzaMoreApp.Views.Home
{
    using System;
    using SimpleMVC.Interfaces;
    using System.IO;

    public class Signin : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/signin.html");
        }
    }
}
