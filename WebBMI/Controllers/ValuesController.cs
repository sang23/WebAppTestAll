using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebBMI.Controllers
{
    
    [ApiController]
    public class ValuesController : Controller
    {
        [Route("Example/api/CalculateBMI")]
        [HttpPost]
        public ActionResult<string> Post([FromBody] BMI model)
        {
            decimal rep = model.Weight / ((model.Height / 100) * (model.Height / 100));

            return rep.ToString("0.00");
        }

    }
}
