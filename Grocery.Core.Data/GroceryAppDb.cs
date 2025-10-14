using Microsoft.EntityFrameworkCore;
using Grocery.Core.Models;

namespace Grocery.Core.Data
{
    public class GroceryAppDb : DbContext
    {
        public DbSet<GroceryListItem> GroceryListItems { get; set; }
        public DbSet<Product> Products { get; set; }
        // Add other DbSets as needed

        public GroceryAppDb(DbContextOptions<GroceryAppDb> options)
            : base(options)
        {
        }
    }
}