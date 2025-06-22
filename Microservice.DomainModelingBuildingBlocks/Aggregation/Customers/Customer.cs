
namespace Microservice.DomainModelingBuildingBlocks.Aggregation.Customers;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> OrderIds { get; set; }
}