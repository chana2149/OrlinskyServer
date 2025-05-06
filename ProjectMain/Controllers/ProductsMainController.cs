using Bl;
using Bl.Api;
using BL.Api;
using BL.Models;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsMainController : ControllerBase
    {
        IBlProductsMain productsMain;
        IBlProducts products;


        public ProductsMainController(Ibl manager)
        {
            productsMain = manager.ProductsMain;
            products =manager.Products;
        }

        [HttpGet("GetByIdProduct")]
        public List<BlProductsMain> GetByIdProduct(int id)
        {
           return productsMain.GetByIdProduct(id);
        }


        [HttpPut("Update")]
        public void upDate(int o)
        {
            productsMain.Update(o);
        }
        [HttpPut("notUse/{id}")]
        public IActionResult notUse(int id)
        {
            productsMain.notUse(id);
            return Ok(products.Get());
        }

        [HttpPost("Add")]
        public async Task<IActionResult> CreateAsync(BlProductsMain o)
        {
            try
            {
                await productsMain.CreateAsync(o);
                return Ok(products.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpPost("Add")]
        //public IActionResult Create(BlProductsMain o)
        //{
        //    productsMain.Create(o);
        //    return Ok(products.Get());
        //}


        /*   [HttpDelete("Delete/{id}")]
           public IActionResult Delete(int id)
           {
               productsMain.Delete(id);
               return Ok(productsMain.Get());
           }*/
    }
}
