using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace iChefWebApi.Configuration
{
    public class WebApiConfig
    {
        public static MySqlConnection DatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["eKitchenDB"].ConnectionString;

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}