using Microsoft.AspNetCore.Mvc;
using BL.Models;
using BL.Api;
using Bl.Api;
using Dal.Models;

namespace ProjectMain.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class SniffimController : ControllerBase
    {
        IBlSniffim  sniffim;
        public SniffimController(Ibl manager)
        {
            sniffim = manager.Sniffim;
        }
        
        [HttpGet("getAll")]
        public List<BlSniffim> Get()
        {
            return sniffim.Get(); 
        }
        [HttpPut("Update")]
        public IActionResult UpDate(BlSniffim o)
        {
            sniffim.Update(o);
         return  Ok(sniffim.Get());
        }


        [HttpPost("Add")]
        public IActionResult Create(BlSniffim o)
        {
            sniffim.Create(o);
            return Ok(sniffim.Get());
        }

    }
}
