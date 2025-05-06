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
    public class ProductsController : ControllerBase
    {
        IBlProducts products;
        public ProductsController(Ibl manager)
        {
            products = manager.Products;
        }

        [HttpGet("getAll")]
        public List<BlProduct> Get()
        {
            return products.Get();
        }
        [HttpGet("getByCattegory/{cat}")]
        public List<BlProduct> GetByCattegory(int cat)
        {
            return products.GetByCattegory(cat);
        }

        [HttpGet("getById/{id}")]
        public BlProduct GetById(int id)
        {
            return products.GetById(id);
        }


        [HttpPut("Update")]
        public IActionResult UpDate(BlProduct o)
        {
            products.Update(o);
            return Ok(products.Get());

        }

        [HttpPost("Add")]
        public IActionResult Create(BlProduct o)
        {
            products.Create(o);
            return Ok(products.Get());
        }
    }
}
