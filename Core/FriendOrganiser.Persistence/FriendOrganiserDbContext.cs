#nullable disable
using FriendOrganiser.Domain.Common;
using FriendOrganiser.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FriendOrganiser.Infrastructure.Persistence
{
    public class FriendOrganiserDbContext : IdentityDbContext<IdentityUser>
    {
        public FriendOrganiserDbContext(DbContextOptions<FriendOrganiserDbContext> options) : base(options)
        {

        }
        public DbSet<Friend> Friends { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FriendOrganiserDbContext).Assembly);

            //seed data here
            //var partGuid = new Guid("31ae5210-236f-4e65-ac59-b6b16e204c9e");
            //modelBuilder.Entity<Part>().HasData(new Part{
            //    PartId = partGuid,
            //    PartNum = "MATT-NEW-PART",
            //    PartDescription = "MATT-NEW-PART"
            //});
            
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
