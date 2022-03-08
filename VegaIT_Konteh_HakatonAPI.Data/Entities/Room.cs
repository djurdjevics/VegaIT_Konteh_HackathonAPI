using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaIT_Konteh_HakatonAPI.Data.Entities
{
    [Table("Room")]
    public class Room
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid FacultyID { get; set; }
        public virtual ICollection<Desk> Desks { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
