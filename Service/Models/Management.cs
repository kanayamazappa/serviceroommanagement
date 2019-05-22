using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Management
    {
        [Key]
        public int IdManagement { get; set; }
        public int IdRoom { get; set; }
        public Room Room { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<ManagementSchedule> ManagementSchedules { get; set; }
    }
}
