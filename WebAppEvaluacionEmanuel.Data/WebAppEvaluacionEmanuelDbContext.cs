using Microsoft.EntityFrameworkCore;
using WebAppEvaluacionEmanuel.Data.Models;

namespace WebAppEvaluacionEmanuel.Data
{
    public class WebAppEvaluacionEmanuelDbContext : DbContext
    {
        public WebAppEvaluacionEmanuelDbContext() : base()
        {

        }

        public WebAppEvaluacionEmanuelDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=EMANUEL\\SQLEXPRESS;Database=evaluacion_emanuel;User ID=sa;Password=admin123");
            }
        }
    }
}
