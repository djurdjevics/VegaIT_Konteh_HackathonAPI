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
    public class DesksController:ControllerBase
    {
        private readonly IDeskService deskService ;
        public DesksController(IDeskService deskService)
        {
            this.deskService = deskService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeskDomainModel>>> GetAllDesksASync([FromQuery] Guid id)
        {
            var result = await deskService.GetAllDesksByFacultyIDAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public  ActionResult<IEnumerable<DeskDomainModel>> InsertDesk([FromBody] DeskDomainModel desk)
        {
            var result =  deskService.Insert(desk);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<DeskDomainModel>>> DeleteDeskByIDASync(Guid id)
        {
            var result = await deskService.Delete(id);
            return Ok(result);
        }
    }



}
