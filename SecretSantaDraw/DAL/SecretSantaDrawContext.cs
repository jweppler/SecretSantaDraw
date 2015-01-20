using SecretSantaDraw.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SecretSantaDraw.DAL
{
    public class SecretSantaDrawContext : DbContext
    {
        public DbSet<Profile> Profile { get; set; }
        public DbSet<WishItem> WishItem { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}