using ClassLibrary1.ETClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary1.ETClasses.Order;

namespace ClassLibrary1.Data
{

    public class PharmaDbContext : DbContext
    {
        public PharmaDbContext() : base("name = PharmaDb")
        {

        }
        public DbSet<Admin> Admin => Set<Admin>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Medicine> Medicines => Set<Medicine>();
        public DbSet<Orders> Orders => Set<Orders>();

    }
}
