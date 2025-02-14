using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using OfficeOpenXml; 
using iTextSharp.text; 
using iTextSharp.text.pdf; 
using System.Text;

namespace AlpineMode.Controllers
{
    public class ReportingMakeController : Controller
    {
        public IActionResult GenerateReport(string format)
        {
            var reportData = GetReportData();

            switch (format.ToLower())
            {
                case "pdf":
                    return GeneratePdfReport(reportData);
                case "xlsx":
                    return GenerateExcelReport(reportData);
                case "csv":
                    return GenerateCsvReport(reportData);
                default:
                    return BadRequest("Invalid format");
            }
        }

        private object GetReportData()
        {
            return new[] {
                new { OrderID = 1, CustomerName = "John Doe", Amount = 100 },
                new { OrderID = 2, CustomerName = "Jane Smith", Amount = 150 }
            };
        }

        private IActionResult GeneratePdfReport(object data)
        {
            var document = new Document();
            var memoryStream = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();
            document.Add(new Paragraph("Report"));
            document.Add(new Paragraph("Generated on: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

            foreach (var item in (dynamic)data)
            {
                document.Add(new Paragraph($"Order ID: {item.OrderID}, Customer: {item.CustomerName}, Amount: {item.Amount}"));
            }

            document.Close();
            return File(memoryStream.ToArray(), "application/pdf", "report.pdf");
        }

        private IActionResult GenerateExcelReport(object data)
        {
            var memoryStream = new MemoryStream();
            using (var package = new ExcelPackage(memoryStream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Report");

                worksheet.Cells[1, 1].Value = "Order ID";
                worksheet.Cells[1, 2].Value = "Customer Name";
                worksheet.Cells[1, 3].Value = "Amount";

                int row = 2;
                foreach (var item in (dynamic)data)
                {
                    worksheet.Cells[row, 1].Value = item.OrderID;
                    worksheet.Cells[row, 2].Value = item.CustomerName;
                    worksheet.Cells[row, 3].Value = item.Amount;
                    row++;
                }

                package.Save();
            }

            return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report.xlsx");
        }

        private IActionResult GenerateCsvReport(object data)
        {
            var csv = new StringBuilder();
            csv.AppendLine("Order ID, Customer Name, Amount");

            foreach (var item in (dynamic)data)
            {
                csv.AppendLine($"{item.OrderID}, {item.CustomerName}, {item.Amount}");
            }

            return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "report.csv");
        }
    }
}
