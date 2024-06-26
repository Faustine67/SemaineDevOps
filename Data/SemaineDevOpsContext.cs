using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SemaineDevOps.Models;

namespace SemaineDevOps.Data
{
    public class SemaineDevOpsContext : DbContext
    {
        public SemaineDevOpsContext (DbContextOptions<SemaineDevOpsContext> options)
            : base(options)
        {
        }

        public DbSet<SemaineDevOps.Models.Entreprise> Entreprise { get; set; } = default!;
    }
}
