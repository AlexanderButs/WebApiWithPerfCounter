using System.Web.Http;

using Owin;

namespace WebApiWithPerfCounter
{
	public class Startup
	{
		public void Configuration(IAppBuilder appBuilder)
		{
			var config = new HttpConfiguration();

			// Web API routes
			config.MapHttpAttributeRoutes();
			config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;
		}
	}
}