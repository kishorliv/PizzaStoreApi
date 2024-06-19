using Microsoft.EntityFrameworkCore;
using PizzaStoreApi.Models;

namespace PizzaStoreApi.Data
{
    public class ApplicationDBContext: DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {}

        public DbSet<Pizza> Pizza {get; set;}
        
    }
}