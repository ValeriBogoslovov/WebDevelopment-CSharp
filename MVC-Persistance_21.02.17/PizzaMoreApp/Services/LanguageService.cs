

namespace PizzaMoreApp.Services
{
    using SimpleHttpServer.Models;

    public static class LanguageService
    {
        public static void SetLanguange(HttpResponse response, string language)
        {
            var lang = new Cookie("lang", language);
            response.Header.Cookies.Add(lang);
        }
    }
}
