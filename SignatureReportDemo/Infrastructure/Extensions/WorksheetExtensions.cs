using System.Drawing;
using System.Net;
using OfficeOpenXml;

namespace SignatureReportExample.Infrastructure.Extensions
{
    public static class WorksheetExtensions
    {
        public static void add_cell_for(this ExcelWorksheet worksheet, int row, string column, string value)
        {
            var cell = string.Format("{0}{1}", column, row);
            worksheet.Cells[cell].Value = value;
        }

        public static void add_image_cell_for(this ExcelWorksheet worksheet, int row, int column, string url)
        {
            var image = get_image_from_url(url);

            using (var bitmap = new Bitmap(image.Width, image.Height))
            {
                using (Graphics graphic = Graphics.FromImage(bitmap))
                {
                    graphic.Clear(Color.White);
                    graphic.DrawImageUnscaled(image, 0, 0);
                }

                add_image_to_worksheet(worksheet, row, column, bitmap);
            }
        }

        static void add_image_to_worksheet(ExcelWorksheet worksheet, int row, int column, Bitmap bitmap)
        {
            var image_name = string.Format("signature_{0}_{1}", row, column);
            var picture = worksheet.Drawings.AddPicture(image_name, bitmap);
            picture.From.Column = column;
            picture.From.Row = row;
            picture.To.Column = column;
            picture.To.Row = row;
        }

        static Image get_image_from_url(string url)
        {
            var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            var httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var stream = httpWebReponse.GetResponseStream();
            return Image.FromStream(stream);
        }
    }
}