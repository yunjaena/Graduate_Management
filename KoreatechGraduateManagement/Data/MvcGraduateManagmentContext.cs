using KoreatechGraduateManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Data
{
    public class MvcGraduateManagmentContext : DbContext
    {
        public MvcGraduateManagmentContext(DbContextOptions<MvcGraduateManagmentContext> options)
            : base(options)
        {
        }

        public DbSet<EtcStatus> EtcStatus { get; set; }
        public DbSet<GraduateCredit> GraduateCredit { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<User> User { get; set; }
    }
}

