using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegaIT_Konteh_HakatonAPI.Data.Entities
{
    [Table("WorkingHours")]
    public class WorkingHours
    {
        public int ID { get; set; }
        public DateTime Opens { get; set; }
        public DateTime Closes { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
