using HVCPU.Mappings.NoRuntime;

namespace HVCPU.Types;

public class Vector<T> : Tp
{
    public Pointer<T>[] vals { get; set; } = new Pointer<T>[1];
    public int Length { get; set; }

    public T this[int index]
    {
        get {
            return vals[index].Dereference();
        }

        set {
            vals[index] = new Pointer<T>(value);
        }
    }
}