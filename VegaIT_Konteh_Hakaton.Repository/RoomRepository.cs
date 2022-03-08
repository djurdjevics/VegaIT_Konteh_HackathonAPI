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
    public interface IRoomRepository:IRepository<Room>
    {
        Task<IEnumerable<Room>> GetByIDAsync(Guid id);
    }
    public class RoomRepository : IRoomRepository
    {
        private HackathonContext _hackathonContext;
        public RoomRepository(HackathonContext hackathonContext)
        {
            _hackathonContext = hackathonContext;
        }


        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _hackathonContext.Rooms.Include(x=>x.Faculty).Include(x=>x.Desks).ToListAsync(); 
        }

        public async Task<IEnumerable<Room>> GetByIDAsync(Guid id)
        {
            return await _hackathonContext.Rooms.Include(x => x.Faculty).Include(x => x.Desks).Where(x => x.FacultyID == id).ToListAsync();
        }
    }
}
