#nullable disable
using FriendOrganiser.Domain.Common;
using FriendOrganiser.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganiser.Infrastructure.Persistence
{
    public class FriendOrganiserDbContext : DbContext
    {
        public FriendOrganiserDbContext(DbContextOptions<FriendOrganiserDbContext> options) : base(options)
        {

        }
        public DbSet<Friend> Friend { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FriendOrganiserDbContext).Assembly);

            modelBuilder.Entity<Friend>().HasData(new Friend
            {
                Id = 1,
                FirstName = "Apple",
                LastName = "banana",
                Email = "apple@banana.com"
            },
            new Friend
            {
                Id = 2,
                FirstName = "Jimbo",
                LastName = "Hardman",
                Email = "jimbo@hardman.com"
            });

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
