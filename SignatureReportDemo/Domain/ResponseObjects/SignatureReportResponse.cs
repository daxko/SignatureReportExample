using System.Collections.Generic;
using SignatureReportExample.Domain.Models;

namespace SignatureReportExample.Domain.ResponseObjects
{
    public class SignatureReportResponse
    {
        public List<SignatureRecords> data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }
}