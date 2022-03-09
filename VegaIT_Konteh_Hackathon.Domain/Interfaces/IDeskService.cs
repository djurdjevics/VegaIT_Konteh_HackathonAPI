using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaIT_Konteh_Hackathon.Domain.DomainModels;

namespace VegaIT_Konteh_Hackathon.Domain.Interfaces
{
    public interface IDeskService
    {
        Task<IEnumerable<DeskDomainModel>> GetAllDesksASync();
        Task<IEnumerable<DeskDomainModel>> GetAllDesksByFacultyIDAsync(Guid roomId);
        Task<DeskDomainModel> Delete(Guid id);
        DeskDomainModel Insert(DeskDomainModel deskDomainModel);
    }
}
