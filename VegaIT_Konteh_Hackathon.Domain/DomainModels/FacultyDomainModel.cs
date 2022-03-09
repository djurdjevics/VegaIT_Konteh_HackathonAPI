using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaIT_Konteh_Hackathon.Domain.DomainModels
{
    public class FacultyDomainModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public WorkingHoursDomainModel WorkingHours { get; set; }
        public List<RoomDomainModel> RoomDomainModels { get; set; }
    }
}
