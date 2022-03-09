using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaIT_Konteh_Hackathon.Domain.DomainModels
{
    public class RoomDomainModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid FacultyID { get; set; }
        public List<DeskDomainModel> DeskDomainModels { get; set; }
    }
}
