using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class ManagementSchedule
    {
        [Key, Column(Order = 1)]
        public int IdManagement { get; set; }
        [Key, Column(Order = 2)]
        public int IdSchedule { get; set; }
        [JsonIgnore]
        public Management Management { get; set; }
        [JsonIgnore]
        public Schedule Schedule { get; set; }
    }
}
