using App.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Line>()
                .HasOne(l => l.FirstNode)
                .WithMany()
                .HasForeignKey(l => l.FirstNodeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Line>()
                .HasOne(l => l.SecondeNode)
                .WithMany()
                .HasForeignKey(l => l.SecondeNodeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Line> Lines { get; set; }
    }
}
