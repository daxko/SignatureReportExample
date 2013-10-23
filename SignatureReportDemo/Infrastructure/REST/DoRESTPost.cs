using RestSharp;

namespace SignatureReportExample.Infrastructure.REST
{
    public interface IDoRESTPosts<Response>
    {
        IRestResponse<Response> run(string path, object request_object);
    }

    public class DoRESTPost<T> : IDoRESTPosts<T> where T : new()
    {
        RestClient client;

        public DoRESTPost()
        {
            client = RestClientBuilder.build();
        }

        public IRestResponse<T> run(string path, object request_object)
        {
            var request = new RestRequest("authenticate/user", Method.POST);

            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            request.AddBody(request_object);

            return client.Execute<T>(request);
        }
    }
}