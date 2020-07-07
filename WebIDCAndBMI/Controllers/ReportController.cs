using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DevExpress.DataAccess.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebIDCAndBMI.Report;

namespace WebIDCAndBMI.Controllers
{
    
    [ApiController]
    public class ReportController : ControllerBase
    {

        [Route("xxxx")]
        [HttpGet]
        public IActionResult PrintReportTaxExemption()
        {
            getReportClass db = new getReportClass();
            try
            {
                var memoryStream = db.GetReportXXXXX();
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StreamContent(memoryStream);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = string.Format("{0}.pdf", "Filename")
                };
                return ResponseMessage(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private IActionResult InternalServerError(Exception ex)
        {
            throw new NotImplementedException();
        }

        private IActionResult ResponseMessage(HttpResponseMessage result)
        {
            throw new NotImplementedException();
        }
    }
}
