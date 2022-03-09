using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaIT_Konteh_Hackathon.Domain.DomainModels;
using VegaIT_Konteh_Hackathon.Domain.Interfaces;
using VegaIT_Konteh_Hakaton.Repository;
using VegaIT_Konteh_HakatonAPI.Data.Entities;

namespace VegaIT_Konteh_HackathonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyService facultyService;
        private readonly IFacultyRepository facultyRepository;
        public FacultiesController(IFacultyService facultyService,IFacultyRepository facultyRepository)
        {
            this.facultyService = facultyService;
            this.facultyRepository = facultyRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultyDomainModel>>> GetAllFaculties()
        {
            var data = await facultyService.GetAllFacultiesASync();
            return Ok(data);
        }
    }
}
