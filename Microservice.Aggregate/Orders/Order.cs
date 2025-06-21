
namespace Microservice.Aggregate.Orders;

/// <summary>
/// Order : Aggregate Root
/// </summary>
public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public List<OrderLine> OrderLines { get; set; }

    public void AddOrderLine(int productId, int quantity, decimal price)
    {
        var orderLine = new OrderLine
        {
            ProductId = productId,
            Count = quantity,
            Price = price
        };
        
        OrderLines.Add(orderLine);
    }
}