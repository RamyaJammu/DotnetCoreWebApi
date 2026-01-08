using DotnetCoreWebApi.Models;
using DotnetCoreWebApi.SErvices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;


namespace DotnetCoreWebApi.Controllers
{
    [Route("api/Product")]
    [ApiController]
    [Authorize]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productRepository.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

            [HttpGet]
            [Route("GetProductById/{id:int}")]

            public IActionResult GetProductById(int id)
            {
                try
                {
                    var product = _productRepository.GetProductById(id);
                    return Ok(product);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal server error: " + ex.Message);
                }
            }

        [HttpGet]
        [Route("GetProduct/{category:alpha}")]

        public IActionResult GetProductByCategory(string category)
        {
            try
            {

                var products = _productRepository.GetProductByCategory(category);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

                [HttpPost]
                [Route("SaveProduct")]
                public IActionResult SaveProduct([FromBody] Product product)
                {
                    try
                    {
                if (ModelState.IsValid)
                {
                    var result = _productRepository.AddProduct(product);
                    return Ok(result);
                }
                return BadRequest("Invalid product data.");

            }
                    catch (Exception ex)
                    {
                        return StatusCode(500, "Internal server error: " + ex.Message);
                    }
                }
        [HttpPut]
        [Route("UpdateProduct")]

        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var update = _productRepository.UpdateProduct(product);
                    return Ok(update);
                }
            
            return BadRequest("Invalid product data.");
        }


            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


                [HttpDelete]
                [Route("DeleteProduct/{id:int}")]
                public IActionResult DeleteProduct(int id)
                {
                    try
                    {
                        var pro = _productRepository.DeleteProduct(id);
                        return Ok(pro);
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, "Internal server error: " + ex.Message);
                    }
                }
            }
        }
    

