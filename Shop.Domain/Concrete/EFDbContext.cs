using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entities;
using System.Data.Entity;


namespace Shop.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Ware> Wares { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderWare> OrderWares { get; set; }
    }
}