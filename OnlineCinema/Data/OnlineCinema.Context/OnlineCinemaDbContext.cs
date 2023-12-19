using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Context.Entities;

namespace OnlineCinema.Context;

public class OnlineCinemaDbContext : DbContext
{
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<PaymentEntity> Payments { get; set; }
    public DbSet<SubscriptionEntity> Subscriptions { get; set; }
    public DbSet<MovieEntity> Movies { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }


    public OnlineCinemaDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<RoleEntity>().HasKey(x => x.Id);
        //modelBuilder.Entity<RoleEntity>().HasIndex(x => x.ExternalId).IsUnique();


        //modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        //modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        //modelBuilder.Entity<UserEntity>().HasOne(x => x.Role)
        //    .WithMany(x => x.Users)
        //    .HasForeignKey(x => x.RoleId);

        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("user_logins").HasNoKey();
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable("user_tokens").HasNoKey(); ;
        modelBuilder.Entity<RoleEntity>().ToTable("user_roles");
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("user_role_claims");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("user_role_owners").HasNoKey();

        //modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        //modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        //modelBuilder.Entity<UserEntity>().HasOne(x => x.Club)
        //    .WithMany(x => x.Users)
        //    .HasForeignKey(x => x.ClubId);




        modelBuilder.Entity<PaymentEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<PaymentEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<PaymentEntity>().HasOne(x => x.User)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.UserId);
        modelBuilder.Entity<PaymentEntity>().HasOne(x => x.Subscription)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.SubscriptionId);


        modelBuilder.Entity<SubscriptionEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<SubscriptionEntity>().HasIndex(x => x.ExternalId).IsUnique();


        modelBuilder.Entity<SubscriptionEntity>().HasMany(x => x.Movies).WithMany(x => x.Subscriptions).UsingEntity(t => t.ToTable("movie_subscription"));


        modelBuilder.Entity<MovieEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<MovieEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<MovieEntity>().HasOne(x => x.Genre)
            .WithMany(x => x.Movies)
            .HasForeignKey(x => x.GenreId);


        modelBuilder.Entity<GenreEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<GenreEntity>().HasIndex(x => x.ExternalId).IsUnique();
    }
}
