using KoreatechGraduateManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Data
{
    public class MvcEtcStatusContext : DbContext
    {
        public MvcEtcStatusContext(DbContextOptions<MvcEtcStatusContext> options)
            : base(options)
        {
        }

        public DbSet<EtcStatus> EtcStatus { get; set; }
    }
}
