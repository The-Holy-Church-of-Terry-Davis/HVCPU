namespace HVCPU;

public unsafe class UnsafePtr
{
    public byte value;

    public UnsafePtr(byte val)
    {
        value = val;
    }

    public byte Dereference()
    {
        return value;
    }

    public void Set(byte val)
    {
        value = val;
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(UnsafePtr value1, UnsafePtr value2) => value1.Equals(value2.Dereference());
    public static bool operator !=(UnsafePtr value1, UnsafePtr value2) => !value1.Equals(value2.Dereference());
}