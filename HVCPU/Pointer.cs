namespace HVCPU;

public class Pointer<T>
{
    public ref T value 
    {
        get {
            return ref value;
        }
    }

    public Pointer(ref T val)
    {
        value = val;
    }

    public T Dereference()
    {
        return value;
    }

    public void Set(T val)
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

    public static bool operator ==(T value1, Pointer<T> value2) => value1.Equals(value2.Dereference());
    public static bool operator !=(T value1, Pointer<T> value2) => !value1.Equals(value2.Dereference());
}