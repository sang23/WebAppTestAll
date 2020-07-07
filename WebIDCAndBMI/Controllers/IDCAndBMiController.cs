using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebIDCAndBMI.Controllers
{
    [Route("Example/api/")]
    [ApiController]
    public class IDCAndBMiController : ControllerBase
    {
        [Route("ValidateCitizenId/{CitizenId}")]
        [HttpGet]
        public ActionResult<bool> Get(string CitizenId)
        {
			char[] numberChars = CitizenId.ToCharArray();

			int total = 0;
			int mul = 13;
			int mod, mod2;
			int nsub;
			int numberChars12;

			for (int i = 0; i < numberChars.Length - 1; i++)
			{
				int num;
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

		[Route("CalculateBMI")]
		[HttpPost]
		public ActionResult<string> Post([FromBody] BMI demel)
        {
			decimal res = demel.Weight / ((demel.Height / 100) * (demel.Height / 100));

			double x = (double)res;

            if (x < 18.50)
            {
				return res.ToString("0.00" + " = " + "น้ำหนักน้อย / ผอม");
			}
			if (x >= 18.50 && x <= 22.99)
			{
				return res.ToString("0.00" + " = " + "ปกติ (สุขภาพดี)");
			}
			if (x >= 23 && x <= 24.99)
			{
				return res.ToString("0.00" + " = " + "ท้วม / โรคอ้วนระดับ 1");
			}
			if (x >= 25 && x <= 29.99)
			{
				return res.ToString("0.00" + " = " + "อ้วน / โรคอ้วนระดับ 2");
			}
            else
            {
				return res.ToString("0.00" + " = " + "อ้วนมาก / โรคอ้วนระดับ 3");
			}
			
		}

		private readonly IConfiguration Configuration;

		public IDCAndBMiController(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		[Route("GetCircleArea/{radius}")]
		[HttpGet]
		public ActionResult<string> Get(int radius)
        {
			decimal pi;
			decimal.TryParse(Configuration["Pi"], out pi);
			decimal res = pi * (radius * radius);
			return res.ToString("0.00");
        }
    }
}
