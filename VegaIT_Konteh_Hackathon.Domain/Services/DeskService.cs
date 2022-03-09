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
    public class DeskService : IDeskService
    {
        private readonly IDeskRepository deskRepository;
        public DeskService(IDeskRepository deskRepository)
        {
            this.deskRepository = deskRepository;
        }
        public async Task<DeskDomainModel> Delete(Guid id)
        {
            var data = await deskRepository.Delete(id);
            deskRepository.Save();
            DeskDomainModel deletedDesk = new DeskDomainModel
            {
                ID = data.ID,
                Available = data.Available,
                Order = data.Order,
                RoomID = data.RoomID
            };
            return deletedDesk;
        }

        public async Task<IEnumerable<DeskDomainModel>> GetAllDesksASync()
        {
            var data = await deskRepository.GetAllAsync();
            if(data == null)
            {
                return new List<DeskDomainModel>();
            }
            List<DeskDomainModel> result = new List<DeskDomainModel>();
            foreach(Desk desk in data)
            {
                result.Add(new DeskDomainModel
                {
                    ID = desk.ID,
                    Available = desk.Available,
                    Order = desk.Order,
                    RoomID = desk.RoomID,
                });
            }
            return result;
        }

        public async Task<IEnumerable<DeskDomainModel>> GetAllDesksByFacultyIDAsync(Guid roomId)
        {
            List<Desk> data;
            if(roomId == Guid.Empty)
            {
                data = (List<Desk>)await deskRepository.GetAllAsync();
            }
            else 
            {
                data = (List<Desk>)await deskRepository.GetDeskByRoom(roomId);
            }
            List<DeskDomainModel> result = new List<DeskDomainModel>();
            foreach (Desk desk in data)
            {
                result.Add(new DeskDomainModel
                {
                    ID = desk.ID,
                    Available = desk.Available,
                    Order = desk.Order,
                    RoomID = desk.RoomID,
                });
            }
            return result;
        }

        public DeskDomainModel Insert(DeskDomainModel deskDomainModel)
        {
            Desk deskToInsert = new Desk
            {
                ID = deskDomainModel.ID,
                Available = deskDomainModel.Available,
                Order = deskRepository.GetNumOfTablesForRoom(deskDomainModel.RoomID),
                RoomID = deskDomainModel.RoomID
            };
            
            var data = deskRepository.Insert(deskToInsert);
            deskRepository.Save();
            return deskDomainModel;
        }
    }
}
