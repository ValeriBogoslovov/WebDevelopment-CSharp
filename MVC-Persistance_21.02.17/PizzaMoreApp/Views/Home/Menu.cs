
namespace PizzaMoreApp.Views.Home
{
    using SimpleMVC.Interfaces.Generic;
    using System.Collections.Generic;
    using System.IO;
    using ViewModels;
    using System;
    using System.Text;

    public class Menu : IRenderable<IEnumerable<PizzasViewModel>>
    {
        private readonly string topPage = File.ReadAllText("../../content/menu-top.html");
        private readonly string bottomPage = File.ReadAllText("../../content/menu-bottom.html");

        public IEnumerable<PizzasViewModel> Model { get; set; }

        public string Render()
        {
            var sb = new StringBuilder();
            sb.AppendLine(topPage);

            foreach (var pizza in Model)
            {
                sb.AppendLine($"<div class=\"thumbnail col-lg-3\" style=\"margin-right: 8%\">");
                sb.AppendLine($"<img src=\"{pizza.ImageUrl}\" alt=\"300x150\">");
                sb.AppendLine($"<div class=\"caption\">");
                sb.AppendLine($"<h3>{pizza.Title}</h3>");
                sb.AppendLine($"<p><small>Recipe: {pizza.Recipe}</small></p>");
                sb.AppendLine($"<p><small>UpVotes: {pizza.UpVotes}</small></p>");
                sb.AppendLine($"<p><small>DownVotes: {pizza.DownVotes}</small></p>");
                sb.AppendLine($"<form method=\"POST\" action=\"/home/menu\">");
                sb.AppendLine($"<input type=\"hidden\" name=\"PizzaId\" value=\"{pizza.Id}\">");
                sb.AppendLine($"<button type=\"submit\" class=\"btn btn-primary\" name=\"Vote\" value=\"1\">Vote Up</button>");
                sb.AppendLine($"<button type=\"submit\" class=\"btn btn-primary\" name=\"Vote\" value=\"-1\">Vote Down</button>");
                sb.AppendLine($"</form>");
                sb.AppendLine($"</div>");
                sb.AppendLine($"</div>");
            }

            sb.AppendLine(bottomPage);
            return sb.ToString();
        }
    }
}
