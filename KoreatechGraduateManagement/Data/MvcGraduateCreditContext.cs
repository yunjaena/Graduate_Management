using KoreatechGraduateManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Data
{
    public class MvcGraduateCreditContext : DbContext
    {
        public MvcGraduateCreditContext(DbContextOptions<MvcGraduateCreditContext> options)
            : base(options)
        {
        }

        public DbSet<GraduateCredit> GraduateCredit { get; set; }
    }
}
