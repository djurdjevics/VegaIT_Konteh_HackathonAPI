using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaIT_Konteh_HakatonAPI.Data.Context;
using VegaIT_Konteh_HakatonAPI.Data.Entities;

namespace VegaIT_Konteh_Hakaton.Repository
{
    public interface IFacultyRepository:IRepository<Faculty>
    {
    }
    public class FacultyRepository : IFacultyRepository
    {
        private HackathonContext _hackathonContext;
        public FacultyRepository(HackathonContext hackathonContext)
        {
            _hackathonContext = hackathonContext;
        }
        public async Task<IEnumerable<Faculty>> GetAllAsync()
        {
            List<Faculty> result = await _hackathonContext.Faculties.Include(x => x.WorkingHours)
                .Include(x => x.Rooms)
                .ThenInclude(x=>x.Desks)
                .ToListAsync();

            return result;
        }
    }
}
