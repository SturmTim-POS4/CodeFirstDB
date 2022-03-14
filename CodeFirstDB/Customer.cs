namespace CodeFirstDB;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<Order> Orders { get; set; }
}