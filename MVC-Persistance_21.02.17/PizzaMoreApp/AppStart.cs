
namespace PizzaMoreApp
{
    using SimpleHttpServer;
    using SimpleMVC;

    public class AppStart
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaMoreApp");
        }
    }
}
