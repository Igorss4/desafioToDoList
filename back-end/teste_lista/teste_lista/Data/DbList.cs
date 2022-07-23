using teste_lista.Models;
using Microsoft.EntityFrameworkCore;

namespace teste_lista.Data
{
    public class DbList : DbContext
    {
        public DbList(DbContextOptions<DbList> options) : base(options)
        {

        }

        public DbSet<Lista> Lista { get; set; }
    }
}
