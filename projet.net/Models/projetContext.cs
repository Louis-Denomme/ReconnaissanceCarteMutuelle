using System;
using Microsoft.EntityFrameworkCore;
namespace projet.net.Models
{
    public class projetContext : DbContext
    {
        public projetContext(DbContextOptions<projetContext> options)
            : base(options)
        {
        }

        public DbSet<Mutuelle> Mutuelles { get; set; }
    }
}
