namespace Microservice.ValueObject.EF.Model.ValueObjects;

public class FirstName
{
    public string Value { get; private set; }

    public FirstName(string value)
    {
        Value = value;
    }
}