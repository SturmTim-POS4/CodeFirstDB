using Microsoft.EntityFrameworkCore;

namespace CodeFirstDB;

public class NorthwndLightDbContext : DbContext
{
    public NorthwndLightDbContext(DbContextOptions<NorthwndLightDbContext> options) : base(options)
    {
        
    }
    public NorthwndLightDbContext(){}
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Shipment> Shipments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine($"Db OnConfiguring: IsConfigured={optionsBuilder.IsConfigured}");
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = @"server=(LocalDB)\mssqllocaldb;attachdbfilename=C:\Temp\NorthwndLight.mdf;database=Persons;integrated security=True;MultipleActiveResultSets=True;";
            Console.WriteLine($"    Using connectionString {connectionString}");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
}