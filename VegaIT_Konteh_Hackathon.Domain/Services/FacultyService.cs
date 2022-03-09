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
    public class FacultyService:IFacultyService
    {
        private readonly IFacultyRepository facultyRepository;
        public FacultyService(IFacultyRepository facultyRepository)
        {
            this.facultyRepository = facultyRepository;
        }

        public async Task<IEnumerable<FacultyDomainModel>> GetAllFacultiesASync()
        {
            var data = await facultyRepository.GetAllAsync();
            List<FacultyDomainModel> result = new List<FacultyDomainModel>();
            if (data == null)
                return null;

            foreach (Faculty faculty in data)
            {
                List<RoomDomainModel> roomDomainModels = new List<RoomDomainModel>();
                foreach (Room room in faculty.Rooms)
                {
                    List<DeskDomainModel> deskDomainModels = new List<DeskDomainModel>();
                    foreach(Desk desk in room.Desks)
                    {
                        deskDomainModels.Add(new DeskDomainModel
                        {
                            ID = desk.ID,
                            Available = desk.Available,
                            Order = desk.Order,
                            RoomID = desk.RoomID
                        });
                    }
                    roomDomainModels.Add(new RoomDomainModel
                    {
                        ID = room.ID,
                        FacultyID = room.FacultyID,
                        Name = room.Name,
                        DeskDomainModels = deskDomainModels 
                    });
                }
                result.Add(new FacultyDomainModel()
                {
                    ID = faculty.ID,
                    Name = faculty.Name,
                    WorkingHours = new WorkingHoursDomainModel
                    {
                        Closes = faculty.WorkingHours.Closes,
                        Opens = faculty.WorkingHours.Opens
                    },
                    RoomDomainModels = roomDomainModels,
                    
                });
            }
            return result;
        }
    }
}
