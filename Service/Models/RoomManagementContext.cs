using Microsoft.EntityFrameworkCore;

namespace Service.Models
{
    public class RoomManagementContext : DbContext
    {
        public RoomManagementContext(DbContextOptions<RoomManagementContext> options) : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Management> Managements { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ManagementSchedule> ManagementSchedules { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Room>().HasKey(r => r.IdRoom);
            builder.Entity<User>().HasKey(u => u.IdUser);
            builder.Entity<Management>().HasKey(m => m.IdManagement);
            builder.Entity<Schedule>().HasKey(s => s.IdSchedule);
            builder.Entity<ManagementSchedule>().HasKey(ms => new { ms.IdManagement, ms.IdSchedule });
            base.OnModelCreating(builder);
           
        }
    }
}
