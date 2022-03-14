namespace CodeFirstDB;

public class Product
{
    public int Id { get; set; }
    public int Weight { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}