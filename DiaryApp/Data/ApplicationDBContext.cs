using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> context)  : base (context)
        {
            
        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        //This below Function we selecteed from the Generate Override optioin from the ApplicationDBContext Class.
        //We will use it to feed data to the Table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry 
                { 
                    Id = 1, 
                    Title = "Did Nothing", 
                    Content = "Absolutely Nothinggg", 
                    Created = DateTime.Today
                },
                new DiaryEntry 
                { 
                    Id = 2, 
                    Title = "Tried something", 
                    Content = "But did absolutely Nothinggg", 
                    Created = DateTime.Today
                },
                new DiaryEntry
                {
                    Id = 3,
                    Title = "Finally Something",
                    Content = "Wait still did Nothinggg",
                    Created = DateTime.Today
                }
                );
        }

        //Steps to Add a Table using Entity Framework
        //1. Create a Model (Class) for the Table (Eg. DiaryEntry)
        //2. Add DB Set
        //3. add-migration AddDiaryEntryTable
        //4. update-database
    }
}
