using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Schedule
    {
        [Key]
        public int IdSchedule { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [JsonIgnore]
        public virtual ICollection<ManagementSchedule> ManagementSchedules { get; set; }
    }
}
