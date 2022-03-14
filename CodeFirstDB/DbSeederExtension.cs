using Microsoft.EntityFrameworkCore;

namespace CodeFirstDB;

public static class DbSeederExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        Console.WriteLine("DbSeederExtension::Seed");
        SeedProducts(modelBuilder);
        SeedCustomers(modelBuilder);
        SeedEmployees(modelBuilder);
        SeedOrders(modelBuilder);
        SeedOrderDetails(modelBuilder);
    }

    private static void SeedProducts(ModelBuilder modelBuilder)
    {
        File.ReadAllLines("Products.csv")
            .Skip(1)
            .Select(x => x.Split(";"))
            .ToList()
            .ForEach(x =>
            {
                modelBuilder.Entity<Product>().HasData(new Product()
                {
                    Id = Int32.Parse(x[0]),
                    Weight = Int32.Parse(x[1]),
                    Price = Int32.Parse(x[2]),
                    Description = x[3]
                });
            });
            
    }

    private static void SeedEmployees(ModelBuilder modelBuilder)
    {
        File.ReadAllLines("Employees.csv")
            .Skip(1)
            .Select(x => x.Split(";"))
            .ToList()
            .ForEach(x =>
            {
                modelBuilder.Entity<Employee>().HasData(new Employee
                {
                    Id = Int32.Parse(x[0]),
                    Firstname = x[1],
                    Lastname = x[2]
                });
            });
    }

    private static void SeedOrders(ModelBuilder modelBuilder)
    {
        File.ReadAllLines("Orders.csv")
            .Skip(1)
            .Select(x => x.Split(";"))
            .ToList()
            .ForEach(x =>
            {
                modelBuilder.Entity<Order>().HasData(new Order
                {
                    Id = Int32.Parse(x[0]),
                    Description = x[1],
                    OrderDate = DateTime.Parse(x[2]),
                    CustomerId = Int32.Parse(x[3])
                });
            });
    }

    private static void SeedOrderDetails(ModelBuilder modelBuilder)
    {
        File.ReadAllLines("OrderDetails.csv")
            .Skip(1)
            .Select(x => x.Split(";"))
            .ToList()
            .ForEach(x =>
            {
                modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail
                {
                    Id = Int32.Parse(x[0]),
                    Amount = Int32.Parse(x[1]),
                    OrderId = Int32.Parse(x[2]),
                    ProductId = Int32.Parse(x[3])
                });
            });
    }

    private static void SeedCustomers(ModelBuilder modelBuilder)
    {
        File.ReadAllLines("Customers.csv")
            .Skip(1)
            .Select(x => x.Split(";"))
            .ToList()
            .ForEach(x =>
            {
                modelBuilder.Entity<Customer>().HasData(new Customer
                {
                    Id = Int32.Parse(x[0]),
                    Name = x[1],
                    Latitude = Double.Parse(x[2]),
                    Longitude = Double.Parse(x[3])
                });
            });
    }
}