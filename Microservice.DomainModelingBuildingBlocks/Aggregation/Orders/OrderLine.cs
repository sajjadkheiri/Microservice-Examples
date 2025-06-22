
namespace Microservice.DomainModelingBuildingBlocks.Aggregation.Orders;

public class OrderLine
{
    public int Id { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}