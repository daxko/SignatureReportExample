namespace SignatureReportExample.Domain.ResponseObjects
{
    public class LoginResponse
    {
        public bool authentication { get; set; }
        public UserDetails admin { get; set; }
    }

    public class UserDetails
    {
        public int clientId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int branchId { get; set; }
        public int adminId { get; set; }
    }
}
