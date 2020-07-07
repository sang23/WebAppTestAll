using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppTestAll.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("xxxx")]
        public IActionResult PrintReportTaxExemption()
        {
            var memoryStream = GetReportClass.GetReportXXXXX();
            //HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            //result.Content = new StreamContent(memoryStream);
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            //{
            //    FileName = string.Format("{0}.pdf", "Filename"),
            //};

            return File(memoryStream.ToArray(), "application/octet-stream", "RegisterIPDReport.pdf");

            //return null; // ResponseMessage(result);
        }
    }
}
