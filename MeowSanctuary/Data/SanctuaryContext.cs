using MeowSanctuary.Models;
using Microsoft.EntityFrameworkCore;

namespace MeowSanctuary.Data
{
    public class SanctuaryContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }



        public SanctuaryContext(DbContextOptions<SanctuaryContext> options ) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to One Worker si User
            modelBuilder.Entity<Worker>()
                .HasOne(w => w.User)
                .WithOne(u => u.Worker)
                .HasForeignKey<User>(u => u.WorkerId);

            //Many to Many Worker and Cat
            //cheie compusa
            modelBuilder.Entity<WorkSchedule>()
                .HasKey(ws => new { ws.WorkerId, ws.CatId });

            modelBuilder.Entity<WorkSchedule>()
                .HasOne<Worker>(ws => ws.Worker)
                .WithMany(w => w.WorkSchedules)
                .HasForeignKey(ws => ws.WorkerId);

            modelBuilder.Entity<WorkSchedule>()
                .HasOne<Cat>(ws => ws.Cat)
                .WithMany(c => c.WorkSchedules)
                .HasForeignKey(ws => ws.CatId);

            //One to Many shelter and cat
            modelBuilder.Entity<Shelter>()
                .HasMany(s => s.Cats)
                .WithOne(c => c.Shelter);

            //One to Many worker si job
            modelBuilder.Entity<Job>()
                .HasMany(j => j.Workers)
                .WithOne(w => w.Job);


            base.OnModelCreating(modelBuilder);
        }
    }



}
