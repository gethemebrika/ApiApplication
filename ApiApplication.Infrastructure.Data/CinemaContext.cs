using ApiApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiApplication.Infrastructure.Data
{
    public class CinemaContext : DbContext
    {
        public DbSet<AuditoriumEntity> Auditoriums { get; set; }
        public DbSet<ShowtimeEntity> ShowTimes { get; set; }
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
        
        
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditoriumEntity>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
                build.HasMany(entry => entry.Showtimes).WithOne().HasForeignKey(entity => entity.AuditoriumId);
            });

            modelBuilder.Entity<SeatEntity>(build =>
            {
                build.HasKey(entry => new { entry.AuditoriumId, entry.Row, entry.SeatNumber });
                build.HasOne(entry => entry.Auditorium).WithMany(entry => entry!.Seats).HasForeignKey(entry => entry.AuditoriumId);
            });

            modelBuilder.Entity<ShowtimeEntity>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
                build.HasOne(entry => entry.Movie).WithMany(entry => entry.ShowTimes);
                build.HasMany(entry => entry.Tickets).WithOne(entry => entry.Showtime).HasForeignKey(entry => entry.ShowtimeId);
            });

            modelBuilder.Entity<MovieEntity>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TicketEntity>(build =>
            {
                build.HasKey(entry => entry.Id);
                build.Property(entry => entry.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
