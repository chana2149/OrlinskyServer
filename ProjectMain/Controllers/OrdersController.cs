using Microsoft.AspNetCore.Mvc;
using BL.Models;
using BL.Api;
using Bl.Api;
using Dal.Models;
using System.Collections.Generic;

namespace ProjectMain.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        IBlOrders  order;
        public OrdersController(Ibl manager)
        {
            order = manager.Orders;
        }
        
        [HttpGet("getByIdCostumer/{id}")]
        public List<BlOrder> Get(string id)
        {
            return order.GetByIdCustomer(id); 
        }

        [HttpPost("Add")]
        public void Create(List<BlOrder> o)
        {
            order.Create(o);
        }
    }
}
