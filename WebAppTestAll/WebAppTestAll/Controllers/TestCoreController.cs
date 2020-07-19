using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppTestAll.Controllers
{
    public class TestCoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetData")]
        public IActionResult GetData()
        {
            var results = new List<apiTestClass>()
            {
                new apiTestClass { id = 1, name = "Candy", price = 50, detail = "xxx"},
                new apiTestClass { id = 2, name = "Mool", price = 120000, detail = "xxxxxxx"},
                new apiTestClass { id = 3, name = "Laboon", price = 90000, detail = "xxxxxxxxxxx"}
            };
            return Json(results);
        }
    }
}
