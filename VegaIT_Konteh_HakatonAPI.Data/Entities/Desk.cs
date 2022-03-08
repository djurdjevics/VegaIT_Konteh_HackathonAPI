using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaIT_Konteh_HakatonAPI.Data.Entities
{
    [Table("Desk")]
    public class Desk
    {
        public Guid ID { get; set; }
        public bool Available { get; set; }
        public Guid RoomID { get; set; }
        public int Order { get; set; }
        public virtual Room Room { get; set; }
    }
}
