using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CR_back.Models;



namespace CR_back.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Country{ get; set; }
        public DbSet<liga> liga { get; set; }
        public DbSet<team> team { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<liga>().ToTable("liga");
            modelBuilder.Entity<team>().ToTable("team");
            modelBuilder.Entity<User>().ToTable("User");


            modelBuilder.Entity<Country>()
             .HasOne(l => l.liga)
             .WithOne(c => c.Country)
             .HasForeignKey<liga>(l => l.InCountryID);

            modelBuilder.Entity<team>()
                .HasOne(p => p.liga)
                .WithMany(b => b.team)
                .HasForeignKey(p => p.liga_idliga);


            modelBuilder.Entity<player>()
               .HasOne(p => p.team)
               .WithMany(b => b.player)
               .HasForeignKey(p => p.inTeamID);








        }

        public DbSet<CR_back.Models.player> player { get; set; }
    }
}
 

