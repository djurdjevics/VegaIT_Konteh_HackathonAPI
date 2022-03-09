using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaIT_Konteh_Hackathon.Domain.DomainModels;

namespace VegaIT_Konteh_Hackathon.Domain.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDomainModel>> GetAllRoomsASync();
        Task<IEnumerable<RoomDomainModel>> GetRoomsByFacultyID(Guid id);
    }
}
