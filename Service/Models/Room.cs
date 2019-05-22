using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Room
    {
        public int IdRoom { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        [JsonIgnore]
        public DateTime? CreateDate { get; set; }
        [JsonIgnore]
        public DateTime? AlterDate { get; set; }
        [JsonIgnore]
        public virtual List<Management> Managements { get; set; }
    }
}
