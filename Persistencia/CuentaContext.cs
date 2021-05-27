using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class CuentaContext: DbContext
    {
        public CuentaContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Cuenta> Cuenta {get;set;} 
    }
}