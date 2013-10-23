namespace SignatureReportExample.Infrastructure
{
    public class ClientContext
    {
        static ClientContext instance;
        public static int client_id { get; set; }

        public static ClientContext Instance
        {
            get { return instance ?? (instance = new ClientContext()); }
        }
    }
}
