using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAppTestAll.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("getdata")]
        public IActionResult GetData()
        {
            string json = @"[
              {
                'id': '1',
                'name': 'Product 1',
                'tel': '02345678',
                'email': '111@gmail.com',
                'address': '11/111 111',
                'color': 'green'
              },
              {
                'id': '2',
                'name': 'Product 2',
                'tel': '02345678',
                'email': '222@gmail.com',
                'address': '22/22 22',
                'color': 'green'
              },
              {
                'id': '3',
                'name': 'Product 3',
                'tel': '02345678',
                'email': '333@gmail.com',
                'address': '33/33 333',
                'color': 'green'
              },
              {
                'id': '4',
                'name': 'Product 4',
                'tel': '02345678',
                'email': '444@gmail.com',
                'address': '44/44 444',
                'color': 'green'
              },
              {
                'id': '5',
                'name': 'Product 5',
                'tel': '02345678',
                'email': 'xxx@gmail.com',
                'address': '55/55 555',
                'color': 'green'
              },
              {
                'id': '6',
                'name': 'Product 6',
                'tel': '02345678',
                'email': '666@gmail.com',
                'address': '66/66 66',
                'color': 'green'
              },
            ]";

            List<Data> products = JsonConvert.DeserializeObject<List<Data>>(json);
            return Json(products);
        }
    }
}
