using HVCPU.EngineTypes;

namespace HVCPU;


/*
    If I could get this to work... It would
    quite honestly be the darkest bit of magic
    I would ever have seen created. But C# loves
    hiding pointers in managed code... and the
    GC hates everyone soooo...
    
    Current issue is that this causes a stack overflow
    error. I'm not quite sure why... and I don't see
    any reason to continue with this until I can figure
    out how to fix this.
*/


public class Pointer<T>
{
    public T value;

    public Pointer(T val)
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
