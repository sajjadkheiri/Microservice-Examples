namespace Microservice.DomainModelingBuildingBlocks.Factory;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public CustomerType Type { get; set; }

    private Customer(int id, string firstName, string lastName, CustomerType type)
    {
    }

    public static Customer CreateGoldCustomer(int id, string firstName, string lastName)
    {
        return new Customer(id, firstName, lastName, CustomerType.Gold);
    }

    public static Customer CreateSilverCustomer(int id, string firstName, string lastName)
    {
        return new Customer(id, firstName, lastName, CustomerType.Silver);
    }

    public static Customer CreateBronzeCustomer(int id, string firstName, string lastName)
    {
        return new Customer(id, firstName, lastName, CustomerType.Bronze);
    }
}