using Microsoft.AspNetCore.Mvc;
using BL.Models;
using BL.Api;
using Bl.Api;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectMain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        IBlCustomers costumers;

        public CostumerController(Ibl manager)
        {
            costumers = manager.Customers;
        }

        [HttpGet("getAll")]
        public async Task<List<BlCostumer>> Get()
        {
            return await costumers.GetAsync();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> CreateAsync(BlCostumer c)
        {
            try
            {
                await costumers.CreateAsync(c);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddFav/{idCust}/{idProd}")]
        public async Task<IActionResult> CreateFavoriteAsync(string idCust, int idProd)
        {
            try
            {
                await costumers.CreateFavoriteAsync(idCust, idProd);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteFav/{idCust}/{idProd}")]
        public async Task<IActionResult> RemoveFavorite(string idCust, int idProd)
        {
            try
            {
                await costumers.DeleteFavoriteAsync(idCust, idProd);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await costumers.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }
    }
}