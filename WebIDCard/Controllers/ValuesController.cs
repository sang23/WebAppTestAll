using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebIDCard.Controllers
{
	[Route("Example/api/")]
	[ApiController]
    public class ValuesController : ControllerBase
    {
		[Route("CalculateBMI")]
		[HttpPost]
		public ActionResult<string> Post([FromBody] BMI model)
		{
			decimal rep = model.Weight / ((model.Height / 100) * (model.Height / 100));

			return rep.ToString("0.00");
		}

		[Route("ValidateCitizenId/{CitizenId}")]
        [HttpGet]
        public ActionResult<bool> Get(string CitizenId)
        {
			char[] numberChars = CitizenId.ToCharArray();

			int total = 0;
			int mul = 13;
			int mod = 0, mod2 = 0;
			int nsub = 0;
			int numberChars12 = 0;

			for (int i = 0; i < numberChars.Length - 1; i++)
			{
				int num = 0;
				int.TryParse(numberChars[i].ToString(), out num);

				total = total + num * mul;
				mul = mul - 1;
			}

			mod = total % 11;
			nsub = 11 - mod;
			mod2 = nsub % 10;

			int.TryParse(numberChars[12].ToString(), out numberChars12);

			if (mod2 != numberChars12)
				return false;
			else
				return true;
		}
        
    }
}
