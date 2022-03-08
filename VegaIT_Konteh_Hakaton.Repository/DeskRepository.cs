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
    public interface IDeskRepository:IRepository<Desk>
    {
        Desk Insert(Desk desk);
        Task<Desk> Delete(object id);
        Task<IEnumerable<Desk>> GetDeskByRoom(Guid id);
        void Save();
    }
    public class DeskRepository : IDeskRepository
    {
        private HackathonContext hackathonContext;
        public DeskRepository(HackathonContext hackathonContext)
        {
            this.hackathonContext = hackathonContext;
        }

        public async Task<IEnumerable<Desk>> GetAllAsync()
        {
            return await hackathonContext.Desks.Include(x=>x.Room).ToListAsync(); 
        }

        public async Task<IEnumerable<Desk>> GetDeskByRoom(Guid id)
        {
            return await hackathonContext.Desks.Include(x => x.Room).Where(x => x.RoomID == id).ToListAsync();
        }

        public void Save()
        {
            hackathonContext.SaveChanges();
        }

        public async Task<Desk> Delete(object id)
        {
            Desk existing = await hackathonContext.Desks.FindAsync(id);
            var result = hackathonContext.Desks.Remove(existing);
            Save();
            return result.Entity;
        }

        public Desk Insert(Desk desk)
        {
            var result = hackathonContext.Desks.Add(desk);
            return result.Entity;
        }
    }
}
