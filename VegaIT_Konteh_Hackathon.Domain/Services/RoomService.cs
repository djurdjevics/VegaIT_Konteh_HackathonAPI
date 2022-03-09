using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaIT_Konteh_Hackathon.Domain.DomainModels;
using VegaIT_Konteh_Hackathon.Domain.Interfaces;
using VegaIT_Konteh_Hakaton.Repository;
using VegaIT_Konteh_HakatonAPI.Data.Entities;

namespace VegaIT_Konteh_Hackathon.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public async Task<IEnumerable<RoomDomainModel>> GetAllRoomsASync()
        {
            var data = await roomRepository.GetAllAsync();
            List<RoomDomainModel> result = new List<RoomDomainModel>();
            if(data == null)
            {
                return new List<RoomDomainModel>();
            }
            foreach (var room in data)
            {
                List<DeskDomainModel> deskDomainModels = new List<DeskDomainModel>();
                foreach (var desk in room.Desks)
                {
                    deskDomainModels.Add(new DeskDomainModel
                    {
                        ID = desk.ID,
                        Available = desk.Available,
                        Order = desk.Order,
                        RoomID = desk.RoomID
                    });
                }
                result.Add(new RoomDomainModel()
                {
                    ID = room.ID,
                    Name = room.Name,
                    DeskDomainModels = deskDomainModels,
                    FacultyID = room.FacultyID
                });
            }
            return result;
        }

        public async Task<IEnumerable<RoomDomainModel>> GetRoomsByFacultyID(Guid facultyId)
        {
            List<Room> data;
            if (facultyId == Guid.Empty)
                data = (List<Room>)await roomRepository.GetAllAsync();
            else
                data = (List<Room>)await roomRepository.GetByIDAsync(facultyId);
            List<RoomDomainModel> result = new List<RoomDomainModel>();
            if (data == null)
            {
                return new List<RoomDomainModel>();
            }
            foreach (var room in data)
            {
                List<DeskDomainModel> deskDomainModels = new List<DeskDomainModel>();
                foreach (var desk in room.Desks)
                {
                    deskDomainModels.Add(new DeskDomainModel
                    {
                        ID = desk.ID,
                        Available = desk.Available,
                        Order = desk.Order,
                        RoomID = desk.RoomID
                    });
                }
                result.Add(new RoomDomainModel()
                {
                    ID = room.ID,
                    Name = room.Name,
                    DeskDomainModels = deskDomainModels,
                    FacultyID = room.FacultyID
                });
            }
            return result;
        }
    }
}
