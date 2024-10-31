using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderSystem2024.Models;

namespace OrderSystem2024.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OrderSystem2024.Models.Category> Category { get; set; } = default!;
        public DbSet<OrderSystem2024.Models.Customer> Customer { get; set; } = default!;
        public DbSet<OrderSystem2024.Models.Employee> Employee { get; set; } = default!;
        public DbSet<OrderSystem2024.Models.Order> Order { get; set; } = default!;
        public DbSet<OrderSystem2024.Models.OrderDetail> OrderDetail { get; set; } = default!;
        public DbSet<OrderSystem2024.Models.Product> Product { get; set; } = default!;
        public DbSet<OrderSystem2024.Models.Shipper> Shipper { get; set; } = default!;
        public DbSet<OrderSystem2024.Models.Supplier> Supplier { get; set; } = default!;
    }
}
