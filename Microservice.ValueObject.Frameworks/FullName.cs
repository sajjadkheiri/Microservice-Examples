namespace Microservice.ValueObject.Frameworks;

public class FullName : BaseValueObject<FullName>
{
    public FullName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    protected override bool IsEqual(FullName? other)
        => FirstName == other.FirstName && LastName == other.LastName;

    protected override int ObjectHashCode()
        => FirstName.GetHashCode() ^ LastName.GetHashCode();
}