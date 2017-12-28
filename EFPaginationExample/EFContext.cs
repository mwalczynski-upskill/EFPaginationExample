using System.Data.Entity;
using EFPaginationExample.Models;

namespace EFPaginationExample
{
    public class EfContext : DbContext
    {
        public EfContext() : base("EfExampleExample") { }

        public DbSet<Person> Persons { get; set; }
    }
}

