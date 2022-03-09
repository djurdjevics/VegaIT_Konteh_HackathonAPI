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
        int GetNumOfTablesForRoom(Guid roomId);
        Desk UpdateOrder(Desk updateDesk);
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
            var query = from deskQuery in hackathonContext.Desks where existing.Order < deskQuery.Order && deskQuery.RoomID == existing.RoomID select deskQuery;
            foreach (var d in query)
            {
                UpdateOrder(d);
            }
            return result.Entity;
        }

        public Desk Insert(Desk desk)
        {
            var result = hackathonContext.Desks.Add(desk);
            return result.Entity;
        }

        public int GetNumOfTablesForRoom(Guid roomId)
        {
             var data = hackathonContext.Desks.Where(x => x.RoomID.Equals(roomId)).ToList().Count;
             return data;
        }

        public Desk UpdateOrder(Desk updateDesk)
        {
            updateDesk.Order = updateDesk.Order - 1;
            var result = hackathonContext.Attach(updateDesk).Entity;
            hackathonContext.Entry(updateDesk).State = EntityState.Modified;
            return result;
        }
    }
}
