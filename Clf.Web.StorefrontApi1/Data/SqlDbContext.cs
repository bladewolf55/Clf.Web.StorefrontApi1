using Clf.Web.StorefrontApi1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Clf.Web.StorefrontApi1.Data;

public class SqlDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Address>().HasData(SeedAddresses());
        modelBuilder.Entity<Order>().HasData(SeedOrders());
        modelBuilder.Entity<Customer>().HasData(SeedCustomers());

    }

    private List<Address> SeedAddresses()
    {
        Address billing = new()
        {
            AddressId = 101,
            CustomerId = 1,
            AddressType = "Billing",
            Address1 = "Bill address 1",
            City = "Denver",
            StateAbbreviation = "CO",
            PostalCode = "80201",
        };
        Address shipping1 = new()
        {
            AddressId = 102,
            CustomerId = 1,
            AddressType = "Shipping",
            Address1 = "Ship1 address 1",
            City = "Roscoe",
            StateAbbreviation = "OH",
            PostalCode = "45203"
        };
        Address shipping2 = new()
        {
            AddressId = 103,
            CustomerId = 1,
            AddressType = "Shipping",
            Address1 = "Ship2 address 1",
            City = "New York",
            StateAbbreviation = "New York",
            PostalCode = "01332"
        };
        return new()
        {
            billing, shipping1, shipping2
        };
    }

    private List<Order> SeedOrders()
    {
        Order order1 = new()
        {
            OrderId = 11,
            CustomerId = 1,
            ShipToId = 102,
            OrderedOn = DateTime.Parse("2025-04-01")
        };
        Order order2 = new()
        {
            OrderId = 12,
            CustomerId = 1,
            ShipToId = 103,
            OrderedOn = DateTime.Parse("2025-04-01")
        };
        return new() { order1, order2 };
    }

    private List<Customer> SeedCustomers()
    {
        Customer customer = new()
        {
            CustomerId = 1,
            CustomerName = "Pequod"
        };
        return new() { customer };
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        return;
        optionsBuilder.UseSeeding((context, _) =>
        {
            context.Database.EnsureCreated();

            // ADDRESS
            Address billing = new()
            {
                AddressId = 101,
                CustomerId = 1,
                AddressType = "Billing",
                Address1 = "Bill address 1",
                City = "Denver",
                StateAbbreviation = "CO",
                PostalCode = "80201",
            };
            Address shipping1 = new()
            {
                AddressId = 102,
                CustomerId = 1,
                AddressType = "Shipping",
                Address1 = "Ship1 address 1",
                City = "Roscoe",
                StateAbbreviation = "OH",
                PostalCode = "45203"
            };
            Address shipping2 = new()
            {
                AddressId = 103,
                CustomerId = 1,
                AddressType = "Shipping",
                Address1 = "Ship2 address 1",
                City = "New York",
                StateAbbreviation = "New York",
                PostalCode = "01332"
            };
            context.Set<Address>().Add(billing);
            context.Set<Address>().Add(shipping1);
            context.Set<Address>().Add(shipping2);

            // ORDER
            Order order1 = new()
            {
                OrderId = 11,
                CustomerId = 1,
                ShipToId = 102,
                OrderedOn = DateTime.Parse("2025-04-01")
            };
            Order order2 = new()
            {
                OrderId = 12,
                CustomerId = 1,
                ShipToId = 103,
                OrderedOn = DateTime.Parse("2025-04-01")
            };

            context.Set<Order>().Add(order1);
            context.Set<Order>().Add(order2);

            // CUSTOMER
            Customer customer = new()
            {
                CustomerId = 1,
                CustomerName = "Pequod"
            };

            context.Set<Customer>().Add(customer);

            context.SaveChanges();
        });
    }
}

