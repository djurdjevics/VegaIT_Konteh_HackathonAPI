using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VegaIT_Konteh_HakatonAPI.Data.Entities
{
    [Table("Faculty")]
    public class Faculty
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        [Column("WorkingHours")]
        public int WorkingHour { get; set; }
        public virtual WorkingHours WorkingHours { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
