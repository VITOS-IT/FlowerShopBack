using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloverShop.Models
{
    public class ShopContext :DbContext
    {
        public ShopContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
