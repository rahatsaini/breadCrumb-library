using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Author).IsRequired().HasMaxLength(100);
                entity.Property(b => b.IsActive).HasDefaultValue(true);
                entity.Property(b => b.IsAvailable).HasDefaultValue(true);
                entity.Property(b => b.CreatedAtUTC).HasDefaultValue(DateTime.UtcNow);
                entity.Property(b => b.BorrowedAtUTC).HasDefaultValue(null);
                entity.Property(b => b.Description).HasMaxLength(1000);
                entity.Property(b => b.Owner).HasMaxLength(100);
                entity.Property(b => b.BorrowedBy).HasMaxLength(100);

            });

            modelBuilder.Entity<Book>().HasData(
                        new Book
                        {
                            Id = 1,
                            Title = "Clean Code",
                            Author = "Robert C. Martin",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                        },
                        new Book
                        {
                            Id = 2,
                            Title = "The Pragmatic Programmer",
                            Description = "Your journey to mastery",
                            Author = "David Thomas",
                            Owner = "Bob Smith",
                            IsAvailable = false,
                            BorrowedBy = "Mike",
                            BorrowedAtUTC = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAtUTC = new DateTime(2024, 1, 2, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 3,
                            Title = "Design Patterns",
                            Description = "Elements of reusable object-oriented software",
                            Author = "Gang of Four",
                            Owner = "Sarah Connor",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 3, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 4,
                            Title = "Domain Driven Design",
                            Description = "Tackling complexity in the heart of software",
                            Author = "Eric Evans",
                            Owner = "John Doe",
                            IsAvailable = false,
                            BorrowedBy = "Jane",
                            BorrowedAtUTC = new DateTime(2024, 1, 12, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAtUTC = new DateTime(2024, 1, 4, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 5,
                            Title = "Clean Architecture",
                            Description = "A craftsman's guide to software structure",
                            Author = "Robert C. Martin",
                            Owner = "Emma Wilson",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 6,
                            Title = "Refactoring",
                            Description = "Improving the design of existing code",
                            Author = "Martin Fowler",
                            Owner = "Chris Evans",
                            IsAvailable = false,
                            BorrowedBy = "Tom",
                            BorrowedAtUTC = new DateTime(2024, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAtUTC = new DateTime(2024, 1, 6, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 7,
                            Title = "The Art of Computer Programming",
                            Description = "Fundamental algorithms and techniques",
                            Author = "Donald Knuth",
                            Owner = "Lisa Ray",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 7, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 8,
                            Title = "Introduction to Algorithms",
                            Description = "Comprehensive introduction to modern algorithms",
                            Author = "Thomas H. Cormen",
                            Owner = "David Park",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 8, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 9,
                            Title = "You Don't Know JS",
                            Description = "Deep dive into JavaScript mechanics",
                            Author = "Kyle Simpson",
                            Owner = "Mia Chen",
                            IsAvailable = false,
                            BorrowedBy = "Alex",
                            BorrowedAtUTC = new DateTime(2024, 1, 14, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAtUTC = new DateTime(2024, 1, 9, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 10,
                            Title = "JavaScript: The Good Parts",
                            Description = "Unearthing the excellence in JavaScript",
                            Author = "Douglas Crockford",
                            Owner = "Noah Williams",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 11,
                            Title = "Working Effectively with Legacy Code",
                            Description = "Techniques for working with difficult codebases",
                            Author = "Michael Feathers",
                            Owner = "Olivia Brown",
                            IsAvailable = false,
                            BorrowedBy = "Sam",
                            BorrowedAtUTC = new DateTime(2024, 1, 11, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAtUTC = new DateTime(2024, 1, 11, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 12,
                            Title = "The Mythical Man Month",
                            Description = "Essays on software engineering",
                            Author = "Frederick Brooks",
                            Owner = "James Taylor",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 12, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 13,
                            Title = "Code Complete",
                            Description = "A practical handbook of software construction",
                            Author = "Steve McConnell",
                            Owner = "Sophia Martinez",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 13, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 14,
                            Title = "Head First Design Patterns",
                            Description = "A brain-friendly guide to design patterns",
                            Author = "Eric Freeman",
                            Owner = "Liam Anderson",
                            IsAvailable = false,
                            BorrowedBy = "Rachel",
                            BorrowedAtUTC = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAtUTC = new DateTime(2024, 1, 14, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 15,
                            Title = "Continuous Delivery",
                            Description = "Reliable software releases through build and deployment",
                            Author = "Jez Humble",
                            Owner = "Isabella Thomas",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 16,
                            Title = "The Phoenix Project",
                            Description = "A novel about IT, DevOps and helping your business win",
                            Author = "Gene Kim",
                            Owner = "Mason Jackson",
                            IsAvailable = false,
                            BorrowedBy = "Lucy",
                            BorrowedAtUTC = new DateTime(2024, 1, 16, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAtUTC = new DateTime(2024, 1, 16, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 17,
                            Title = "Cracking the Coding Interview",
                            Description = "189 programming questions and solutions",
                            Author = "Gayle Laakmann McDowell",
                            Owner = "Ethan White",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 17, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 18,
                            Title = "Structure and Interpretation of Computer Programs",
                            Description = "Classic MIT computer science textbook",
                            Author = "Harold Abelson",
                            Owner = "Ava Harris",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 18, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 19,
                            Title = "Peopleware",
                            Description = "Productive projects and teams",
                            Author = "Tom DeMarco",
                            Owner = "William Clark",
                            IsAvailable = false,
                            BorrowedBy = "Nina",
                            BorrowedAtUTC = new DateTime(2024, 1, 19, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAtUTC = new DateTime(2024, 1, 19, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new Book
                        {
                            Id = 20,
                            Title = "The Clean Coder",
                            Description = "A code of conduct for professional programmers",
                            Author = "Robert C. Martin",
                            Owner = "Charlotte Lewis",
                            IsAvailable = true,
                            CreatedAtUTC = new DateTime(2024, 1, 20, 0, 0, 0, DateTimeKind.Utc)
                        }
                    );
        }

    }
}
