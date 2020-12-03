using KoreatechGraduateManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Data
{
    public class MvcSubjectContext : DbContext
    {
        public MvcSubjectContext(DbContextOptions<MvcSubjectContext> options)
            : base(options)
        {
        }

        public DbSet<Subject> Subject { get; set; }
    }
}
