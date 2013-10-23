using System.Collections.Generic;
using SignatureReportExample.Domain.Models;

namespace SignatureReportExample.Domain.ResponseObjects
{
    public class ProgramResponse
    {
        public List<ChildCareProgram> programs { get; set; }
    }
}