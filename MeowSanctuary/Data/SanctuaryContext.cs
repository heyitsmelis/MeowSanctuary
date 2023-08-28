using MeowSanctuary.Models;
using Microsoft.EntityFrameworkCore;

namespace MeowSanctuary.Data
{
    public class SanctuaryContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }

        public SanctuaryContext(DbContextOptions<SanctuaryContext> options ) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }



}
