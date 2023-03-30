using Microsoft.EntityFrameworkCore;
using WebApiRuta.Entities;

namespace WebApiRuta.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>
            options)
            : base(options)
        {
        }
        public DbSet<Ruta> Ruta { get; set; }
    }
}
