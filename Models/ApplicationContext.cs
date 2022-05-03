using Floppy.Models.UserModels;
using Floppy.Models.WordModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Floppy.Models
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public DbSet<Word> Words { get; set; }
        public DbSet<WordSet> WordSets { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
