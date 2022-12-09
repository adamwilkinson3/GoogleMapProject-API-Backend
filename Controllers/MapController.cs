using ApiMap.Repository;
using ApiMap.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {

        private readonly MapDbContext _context;

        public MapController(MapDbContext context)
        {
            _context = context;
        }

        // POST api/<MapController>
        [HttpPost]
        public Message Post([FromBody] Mapaddress mapAddress)
        {
            var message = new Message();
            if (ModelState.IsValid)
            {
                _context.Add(mapAddress);
                _context.SaveChanges();
                
                message.Success = true;
                message.Reason = "Location Sent to Database";
                message.Data = mapAddress;

                return message;
            }
            message.Success = false;
            message.Reason = "Error Sending Location to Database";
            message.Data = mapAddress;

            return message;
        }
    }
}
