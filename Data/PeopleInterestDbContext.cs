using Microsoft.EntityFrameworkCore;
using PeopleInterest.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PeopleInterest.Data
{
    public class PeopleInterestDbContext : DbContext
    {
        public PeopleInterestDbContext(DbContextOptions<PeopleInterestDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }
        public DbSet<InterestLink> InterestLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Seed Interests
            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Programming", Description = "The process of writing computer programs." },
                new Interest { Id = 2, Title = "Cooking", Description = "The practice of preparing food." },
                new Interest { Id = 3, Title = "Gardening", Description = "The art of growing plants." }
            );

            // Seed Persons
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Alice", PhoneNumber = "123-456-7890" },
                new Person { Id = 2, Name = "Bob", PhoneNumber = "234-567-8901" },
                new Person { Id = 3, Name = "Charlie", PhoneNumber = "345-678-9012" }
            );

            // Seed PersonInterests
            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { PersonId = 1, InterestId = 1 }, // Alice -> Programming
                new PersonInterest { PersonId = 1, InterestId = 2 }, // Alice -> Cooking
                new PersonInterest { PersonId = 2, InterestId = 2 }, // Bob -> Cooking
                new PersonInterest { PersonId = 2, InterestId = 3 }, // Bob -> Gardening
                new PersonInterest { PersonId = 3, InterestId = 1 }  // Charlie -> Programming
            );

            // Seed InterestLinks
            modelBuilder.Entity<InterestLink>().HasData(
                new InterestLink { Id = 1, Url = "https://learnprogramming.com", InterestId = 1 },
                new InterestLink { Id = 2, Url = "https://cooking101.com", InterestId = 2 },
                new InterestLink { Id = 3, Url = "https://growingplants.com", InterestId = 3 },
                new InterestLink { Id = 4, Url = "https://advancedcooking.com", InterestId = 2 },
                new InterestLink { Id = 5, Url = "https://programmingresources.com", InterestId = 1 }
            );

            modelBuilder.Entity<PersonInterest>()
                .HasKey(pi => new { pi.PersonId, pi.InterestId });

        }
    }
}
