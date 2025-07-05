namespace Microservice.ValueObject.EF.Model.ValueObjects;

public class LastName
{
    public string Value { get; private set; }

    public LastName(string value)
    {
        Value = value;
    }
}