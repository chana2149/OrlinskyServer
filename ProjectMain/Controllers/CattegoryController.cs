using Microsoft.AspNetCore.Mvc;
using BL.Models;
using BL.Api;
using Bl.Api;

namespace ProjectMain.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class CattegoryController: ControllerBase
    {
        IBlCattegory  cattegory;
        public CattegoryController(Ibl manager)
        {
            cattegory = manager.Cattegory;
        }
        
        [HttpGet("getAll")]
        public List<BlCattegory> Get()
        {
            return cattegory.Get(); 
        }

   
    }
}
