using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace devexpress.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly string ReportDirectory;

        [Obsolete]
        public HomeController(IHostingEnvironment env)
        {
            ReportDirectory = env.ContentRootPath;
        }
   

        [HttpGet]
        public IActionResult teste()
        {
            XtraReport newReport = new XtraReport();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Name", typeof(String)));
            dt.Rows.Add(1, "Lucas");
            dt.Rows.Add(2, "Fogaça");
            newReport.DataSource = dt;
            newReport.ExportToPdf(Path.Combine(Directory.GetCurrentDirectory(), "Resources"));
            return new PhysicalFileResult(Path.Combine(Directory.GetCurrentDirectory(), "Resources"), "application/pdf");
        }
    }
}