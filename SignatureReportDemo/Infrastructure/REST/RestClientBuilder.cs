using System.Configuration;
using RestSharp;
using RestSharp.Deserializers;

namespace SignatureReportExample.Infrastructure.REST
{
    public class RestClientBuilder
    {
        public static RestClient build()
        {
            var settings_reader = ConfigurationManager.AppSettings;
            var client = new RestClient(settings_reader["APIUrl"]);
            client.Authenticator = new HttpBasicAuthenticator(settings_reader["APIUsername"], settings_reader["APIPassword"]);
            client.ClearHandlers();
            client.AddHandler("application/json", new JsonDeserializer());
            return client;
        }
    }
}
