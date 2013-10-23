using System.Collections.Generic;
using RestSharp;

namespace SignatureReportExample.Infrastructure.REST
{
    public interface IMakeARESTRequest<Response>
    {
        IRestResponse<Response> run(string path, IEnumerable<QueryParameter> parameters);
    }

    public class MakeRestRequest<Response> : IMakeARESTRequest<Response> where Response : new()
    {
        RestClient client;

        public MakeRestRequest()
        {
            client = RestClientBuilder.build();
        }

        public IRestResponse<Response> run(string path, IEnumerable<QueryParameter> parameters)
        {
            var request_string = build_request_string_for(path);

            var request = new RestRequest(request_string, Method.GET);

            foreach (var query_parameter in parameters)
                request.AddParameter(query_parameter.name, query_parameter.value);

            return client.Execute<Response>(request);
        }

        string build_request_string_for(string path)
        {
            return string.Format("{0}/{1}", 2014, path);
            return string.Format("{0}/{1}", ClientContext.client_id, path);
        }
    }

    public class QueryParameter
    {
        public string name;
        public object value;
    }
}