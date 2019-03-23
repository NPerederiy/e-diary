using Owin;
using System.Web.Http;

namespace eDiary.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();

            config.Filters.Add(new AuthorizeAttribute());

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DiaryApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }
}
