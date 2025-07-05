namespace Microservice.ValueObject.Framework;

public abstract class BaseValueObject<TBaseValueObject> : IEquatable<TBaseValueObject> where TBaseValueObject : BaseValueObject<TBaseValueObject>
{
    public bool Equals(TBaseValueObject? other) => this == other;
    public override bool Equals(object? obj) => base.Equals(obj is TBaseValueObject other && IsEqual(other));
    
    public override int GetHashCode() => ObjectHashCode();

    protected abstract bool IsEqual(TBaseValueObject? other);
    protected abstract int ObjectHashCode();

    public static bool operator ==(BaseValueObject<TBaseValueObject> x, BaseValueObject<TBaseValueObject> y)
    {
        if (x is null && y is null)
            return true;

        if (x is null || y is null)
            return false;

        return x.Equals(y);
    }

    public static bool operator !=(BaseValueObject<TBaseValueObject> x, BaseValueObject<TBaseValueObject> y) => !(x == y);
}