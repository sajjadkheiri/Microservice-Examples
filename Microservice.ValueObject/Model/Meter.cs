namespace Microservice.ValueObject.Model;

public class Meter
{
    private int Distance { get; }

    public Meter(int distance)
    {
        if (distance < default(int))
            throw new Exception("Distance must be greater than zero.");

        Distance = distance;
    }

    public override bool Equals(object? obj)
    {
        var other = obj as Meter;

        if (other is null)
            return false;
        
        return Distance == other.Distance;
    }

    public override int GetHashCode()
    {
        return Distance.GetHashCode();
    }

    public static bool operator ==(Meter left, Meter right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Meter left, Meter right)
    {
        return !Equals(left, right);
    }
}