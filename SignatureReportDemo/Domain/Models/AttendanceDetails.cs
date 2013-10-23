using System;

namespace SignatureReportExample.Domain.Models
{
    public class AttendanceDetails
    {
        public DateTime date { get; set; }
        public int type { get; set; }
        public DateTime checkInTime { get; set; }
        public DateTime checkOutTime { get; set; }
        public string checkInSignatureUrl { get; set; }
        public string checkOutSignatureUrl { get; set; }
    }
}