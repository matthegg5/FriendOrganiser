﻿// <auto-generated />
using FriendOrganiser.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FriendOrganiser.Persistence.Migrations
{
    [DbContext(typeof(FriendOrganiserDbContext))]
    partial class FriendOrganiserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FriendOrganiser.Domain.Entities.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Friend");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "thomas@hubert.com",
                            FirstName = "Thomas",
                            LastName = "Hubert"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jimbo@hardman.com",
                            FirstName = "Jimbo",
                            LastName = "Hardman"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
