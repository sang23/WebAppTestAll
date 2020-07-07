using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebIDCAndBMI.Report;

namespace WebIDCAndBMI
{
    public class getReportClass
    {
        public MemoryStream GetReportXXXXX()
        {
            string[] arrayObjectToPrintReport = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            MemoryStream result = new MemoryStream();
            using (CarReport report = new CarReport())
            {
                report.DataSource = arrayObjectToPrintReport;       // bind object to report
                report.CreateDocument();
                report.ExportToPdf(result);
                report.Dispose();
            }

            result.Position = 0;
            return result;
        }
    }
}
