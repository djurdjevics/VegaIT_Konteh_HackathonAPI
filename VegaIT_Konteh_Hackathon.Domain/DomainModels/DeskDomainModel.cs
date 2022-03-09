using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaIT_Konteh_Hackathon.Domain.DomainModels
{
    public class DeskDomainModel
    {
        public Guid ID { get; set; }
        public int Order { get; set; }
        public bool Available { get; set; }
        public Guid RoomID { get; set; }
    }
}
