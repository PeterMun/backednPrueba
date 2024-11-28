using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendPruebaNexti.Models;
using Microsoft.EntityFrameworkCore;

namespace backendPruebaNexti.Data
{
    public class ApplicationDbContext : DbContext
    {
        // public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options)
          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EventoModel> evento { get; set; }
        
    }
}