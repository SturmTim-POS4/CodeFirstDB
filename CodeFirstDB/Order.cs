using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstDB;

public class Order
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime? OrderDate { get; set; }
    public int CustomerId { get; set; }
    public int? ShipmentId { get; set; }
    public Shipment Shipment { get; set; }
    public Customer Customer { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }

    [NotMapped] public string OrderString => $"{Description} vom {DateOnly.FromDateTime((DateTime) OrderDate)}";
}