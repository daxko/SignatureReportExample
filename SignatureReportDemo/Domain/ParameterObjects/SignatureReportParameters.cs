using System;

namespace SignatureReportExample.Domain.ParameterObjects
{
    public class SignatureReportParameters
    {
        public int program_id { get; set; }
        public int location_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }
}