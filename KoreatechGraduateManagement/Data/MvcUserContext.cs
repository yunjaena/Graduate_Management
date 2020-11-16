using Microsoft.EntityFrameworkCore;
using KoreatechGraduateManagement.Models;

namespace KoreatechGraduateManagement.Data
{
    public class MvcUserContext : DbContext
    {
        public MvcUserContext(DbContextOptions<MvcUserContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
