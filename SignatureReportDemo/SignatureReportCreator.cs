using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using SignatureReportExample.Infrastructure.Extensions;
using SignatureReportExample.Domain.ParameterObjects;
using SignatureReportExample.Domain.ResponseObjects;
using SignatureReportExample.Infrastructure.REST;

namespace SignatureReportExample
{
    public class SignatureReportCreator
    {
        string last_name_col = "A";
        string first_name_col = "B";
        string birth_date_col = "C";
        string attendance_date_col = "D";
        string attendance_type_col = "E";
        string check_in_time_col = "F";
        int check_in_sig_col = 6;
        string check_out_time_col = "H";
        int check_out_sig_col = 8;

        public string run(SignatureReportParameters parameters)
        {
            var report_data = get_report_information(parameters);

            var new_file = new FileInfo(string.Format(@"C:\signature_report_{0}.xlsx", DateTime.Now.Ticks));
            
            using (var excel_package = new ExcelPackage(new_file))
            {
                build_worksheet(excel_package, report_data);

                excel_package.Save();
            }

            return new_file.Name;
        }

        void build_worksheet(ExcelPackage excel_package, SignatureReportResponse report_data)
        {
            int row = 1;
            var worksheet = excel_package.Workbook.Worksheets.Add("Workbook");
            worksheet.add_cell_for(row, last_name_col, "First Name");
            worksheet.add_cell_for(row, first_name_col, "Last Name");
            worksheet.add_cell_for(row, birth_date_col, "Birth Date");
            worksheet.add_cell_for(row, attendance_date_col, "Attendance Date");
            worksheet.add_cell_for(row, attendance_type_col, "Attendance Type");
            worksheet.add_cell_for(row, check_in_time_col, "Check-In Time");
            worksheet.add_cell_for(row, "G", "Check-In Signature");
            worksheet.add_cell_for(row, check_out_time_col, "Check-Out Time");
            worksheet.add_cell_for(row, "I", "Check-Out Signature");
            row++;

            foreach (var member in report_data.data)
            {
                worksheet.add_cell_for(row, last_name_col, member.lastName);
                worksheet.add_cell_for(row, first_name_col, member.firstName);
                worksheet.add_cell_for(row, birth_date_col, member.dateOfBirth.ToShortDateString());
                foreach (var detail in member.details)
                {
                    row++;
                    worksheet.add_cell_for(row, attendance_date_col, detail.date.ToShortDateString());
                    worksheet.add_cell_for(row, attendance_type_col, detail.type.ToString());
                    worksheet.add_cell_for(row, check_in_time_col, detail.checkInTime.ToShortTimeString());
                    if(detail.checkInSignatureUrl != null) worksheet.add_image_cell_for(row, check_in_sig_col, detail.checkInSignatureUrl);
                    worksheet.add_cell_for(row, check_out_time_col, detail.checkOutTime.ToShortTimeString());
                    if(detail.checkOutSignatureUrl != null) worksheet.add_image_cell_for(row, check_out_sig_col, detail.checkOutSignatureUrl);
                }

                row++;
            }
        }

        SignatureReportResponse get_report_information(SignatureReportParameters parameters)
        {
            var report_getter = new MakeRestRequest<SignatureReportResponse>();
            var query_string = string.Format("childcare/programs/{0}/signaturereport", parameters.program_id);
            var result = report_getter.run(query_string, build_report_parameters(parameters));
            return result.Data;
        }

        IEnumerable<QueryParameter> build_report_parameters(SignatureReportParameters parameters)
        {
            yield return new QueryParameter { name = "location_id", value = parameters.location_id };
            yield return new QueryParameter { name = "end_date", value = parameters.end_date };
            yield return new QueryParameter { name = "start_date", value = parameters.start_date };
        }
    }
}