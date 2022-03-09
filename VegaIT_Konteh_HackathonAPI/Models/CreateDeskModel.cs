using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VegaIT_Konteh_HackathonAPI.Models
{
    public class CreateDeskModel
    {
        [Required]
        public  Guid RoomID { get; set; }
    }
}
