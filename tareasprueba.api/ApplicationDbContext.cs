using Microsoft.EntityFrameworkCore;
using tareasprueba.api.Models;

public class ApplicationDbContext : DbContext
    {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
    }
        public DbSet<Tarea> tareas { get; set; }
        public DbSet<EscalarValue> escalarValues { get; set; }
        public DbSet<Tarea_estado> tarea_Estados { get; set; }

      

    }

