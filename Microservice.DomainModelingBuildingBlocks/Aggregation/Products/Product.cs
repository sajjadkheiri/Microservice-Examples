
namespace Microservice.DomainModelingBuildingBlocks.Aggregation.Products;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<int> OrderLineIds { get; set; }
}