using System;
using System.Collections.Generic;

namespace SignatureReportExample.Domain.Models
{
    public class SignatureRecords
    {
        public long id { get; set; }
        public string firstName { get; set; }
        public string  lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public List<AttendanceDetails> details { get; set; }
    }
}