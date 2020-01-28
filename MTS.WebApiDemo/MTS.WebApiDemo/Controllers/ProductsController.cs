using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MTS.WebApiDemo.Controllers
{
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        [HttpGet("Get")]
        public string Get()
        {
            return "products";
        }
    }
}