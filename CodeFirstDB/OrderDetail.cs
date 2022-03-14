using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CodeFirstDB;

public class OrderDetail
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }

    [NotMapped] public string OrderDetailString => $"{Amount} {Product.Description} zu je {Product.Price},00€";
    
}