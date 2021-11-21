using Calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<ToDo> Todos { get; set; }
    }
}