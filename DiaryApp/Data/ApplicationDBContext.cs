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

        //Steps to Add a Table using Entity Framework
        //1. Create a Model (Class) for the Table (Eg. DiaryEntry)
        //2. Add DB Set
        //3. add-migration AddDiaryEntryTable
        //4. update-database
    }
}
