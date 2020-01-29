using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MTS.WebApiDemo.DataAcces;
using MTS.WebApiDemo.Entities;

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
        [HttpPost]
        public IActionResult Post(/*[FromBody] Json İçin*/ Product product)
        {
            try
            {
                _productDal.Add(product);
                //201 created;
                return new StatusCodeResult(201);


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productDal.Update(product);
                //201 created;
                return Ok(product);


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{ProductID}")]
        public IActionResult Delete(int ProductID)
        {
            try
            {
                Product product = _productDal.Get(p => p.ProductID == ProductID);
                _productDal.Delete(product);
                //201 created;
                return Ok(product);


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}