using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTS.WebApiDemo.DataAcces;

namespace MTS.WebApiDemo.Controllers
{

    [Route("api/Products")]
    public class ProductsController : Controller
    {
        IProductDal _productDal;
        public ProductsController(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var products = _productDal.GetList();
            return Ok(products);

        }



        [HttpGet("{productID}")] 
        public IActionResult Get(int productID)
        {
            try
            {
                var result = _productDal.Get(p => p.ProductID == productID);
                if (result == null)
                {
                    return NotFound($"There is no product with ID ={productID}");

                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
           

        }
    }
}