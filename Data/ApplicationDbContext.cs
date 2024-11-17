using GenshinAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GenshinAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Character> Characters { get; set; }
    }
}
