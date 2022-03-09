using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaIT_Konteh_Hackathon.Domain.DomainModels;
using VegaIT_Konteh_Hackathon.Domain.Interfaces;

namespace VegaIT_Konteh_HackathonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController:ControllerBase
    {
        private readonly IRoomService roomService;
        public RoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<RoomDomainModel>>> GetAllRoomsASync([FromQuery] Guid id)
        {
            var data = await roomService.GetRoomsByFacultyID(id);
            return Ok(data);
        }
    }
}
