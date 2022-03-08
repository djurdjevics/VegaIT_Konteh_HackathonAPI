using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaIT_Konteh_HakatonAPI.Data.Context;
using VegaIT_Konteh_HakatonAPI.Data.Entities;

namespace VegaIT_Konteh_Hackathon.Repository
{
    public interface IFacultiesRepository : IRepository<Faculty>
    {

    }

    public class FacultiesRepository:IFacultiesRepository
    {
        private HackathonContext _hackathonContext;

        public FacultiesRepository(HackathonContext hackathonContext)
        {
            _hackathonContext = hackathonContext;
        }
        public async Task<IEnumerable<Faculty>> GetAll()
        {
            List<Faculty> result = await _hackathonContext.Faculties.ToListAsync();
            return result;
        }
    }
}
