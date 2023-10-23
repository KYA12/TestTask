using Microsoft.EntityFrameworkCore;

namespace TestTask.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        // Override the OnModelCreating method to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This is where you configure the self-referencing relationship for the categories
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            // Seed some sample data into the table
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Books", ParentCategoryId = null },
                new Category { CategoryId = 2, CategoryName = "Fiction", ParentCategoryId = 1 },
                new Category { CategoryId = 3, CategoryName = "Non-fiction", ParentCategoryId = 1 },
                new Category { CategoryId = 4, CategoryName = "Science Fiction", ParentCategoryId = 2 },
                new Category { CategoryId = 5, CategoryName = "Fantasy", ParentCategoryId = 2 },
                new Category { CategoryId = 6, CategoryName = "Biography", ParentCategoryId = 3 },
                new Category { CategoryId = 7, CategoryName = "History", ParentCategoryId = 3 },
                new Category { CategoryId = 8, CategoryName = "Ancient Rome", ParentCategoryId = 7 },
                new Category { CategoryId = 9, CategoryName = "Medival Italy", ParentCategoryId = 7 }
            );

        }
    }
}
