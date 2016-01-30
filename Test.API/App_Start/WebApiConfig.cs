using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace Test.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            GlobalConfiguration.Configuration.MessageHandlers.Add(new OptionsHttpMessageHandler());

        }

        public class OptionsHttpMessageHandler : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request.Method == HttpMethod.Options)
                {
                    return Task.Factory.StartNew(() =>
                    {
                        var resp = new HttpResponseMessage(HttpStatusCode.OK);

                        return resp;
                    });
                }
                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}
