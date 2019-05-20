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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Room>().HasKey(r => r.IdRoom);
            builder.Entity<User>().HasKey(u => u.IdUser);
            builder.Entity<Management>().HasKey(m => m.IdManagement);
            base.OnModelCreating(builder);
        }
    }
}
