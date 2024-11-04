﻿// <auto-generated />
using FriendOrganiser.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FriendOrganiser.Persistence.Migrations
{
    [DbContext(typeof(FriendOrganiserDbContext))]
    [Migration("20241101215659_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FriendOrganiser.Domain.Entities.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Friend");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "apple@banana.com",
                            FirstName = "Apple",
                            LastName = "banana"
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