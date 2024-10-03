﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeopleInterest.Data;

#nullable disable

namespace PeopleInterest.Migrations
{
    [DbContext(typeof(PeopleInterestDbContext))]
    [Migration("20241002175637_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PeopleInterest.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The process of writing computer programs.",
                            Title = "Programming"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The practice of preparing food.",
                            Title = "Cooking"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The art of growing plants.",
                            Title = "Gardening"
                        });
                });

            modelBuilder.Entity("PeopleInterest.Models.InterestLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonInterestInterestId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonInterestPersonId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("PersonId");

                    b.HasIndex("PersonInterestPersonId", "PersonInterestInterestId");

                    b.ToTable("InterestLinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InterestId = 1,
                            PersonId = 1,
                            Url = "https://learnprogramming.com"
                        },
                        new
                        {
                            Id = 2,
                            InterestId = 2,
                            PersonId = 1,
                            Url = "https://cooking101.com"
                        },
                        new
                        {
                            Id = 3,
                            InterestId = 3,
                            PersonId = 2,
                            Url = "https://growingplants.com"
                        },
                        new
                        {
                            Id = 4,
                            InterestId = 2,
                            PersonId = 2,
                            Url = "https://advancedcooking.com"
                        },
                        new
                        {
                            Id = 5,
                            InterestId = 1,
                            PersonId = 3,
                            Url = "https://programmingresources.com"
                        });
                });

            modelBuilder.Entity("PeopleInterest.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alice",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bob",
                            PhoneNumber = "234-567-8901"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Charlie",
                            PhoneNumber = "345-678-9012"
                        });
                });

            modelBuilder.Entity("PeopleInterest.Models.PersonInterest", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("InterestId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "InterestId");

                    b.HasIndex("InterestId");

                    b.ToTable("PersonInterests");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            InterestId = 1
                        },
                        new
                        {
                            PersonId = 1,
                            InterestId = 2
                        },
                        new
                        {
                            PersonId = 2,
                            InterestId = 2
                        },
                        new
                        {
                            PersonId = 2,
                            InterestId = 3
                        },
                        new
                        {
                            PersonId = 3,
                            InterestId = 1
                        });
                });

            modelBuilder.Entity("PeopleInterest.Models.InterestLink", b =>
                {
                    b.HasOne("PeopleInterest.Models.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeopleInterest.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeopleInterest.Models.PersonInterest", null)
                        .WithMany("InterestLinks")
                        .HasForeignKey("PersonInterestPersonId", "PersonInterestInterestId");

                    b.Navigation("Interest");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PeopleInterest.Models.PersonInterest", b =>
                {
                    b.HasOne("PeopleInterest.Models.Interest", "Interest")
                        .WithMany("PersonInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeopleInterest.Models.Person", "Person")
                        .WithMany("PersonInterests")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interest");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PeopleInterest.Models.Interest", b =>
                {
                    b.Navigation("PersonInterests");
                });

            modelBuilder.Entity("PeopleInterest.Models.Person", b =>
                {
                    b.Navigation("PersonInterests");
                });

            modelBuilder.Entity("PeopleInterest.Models.PersonInterest", b =>
                {
                    b.Navigation("InterestLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
