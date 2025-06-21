
namespace Microservice.Aggregate.Customers;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<int> OrderIds { get; set; }
}