namespace HVCPU.Types;

public class Chr : Tp
{
    public Pointer<char> ptr { get; set; }
    public new Block<char> mem { get; set; }

    public Chr(char val)
    {
        ptr = new Pointer<char>(val);
        mem = new Block<char>(ptr);
    }

    public static Str operator +(Chr val1, Chr val2) {
        string newval = "";
        newval += val1.ptr.value;
        newval += val2.ptr.value;

        Str ret = new Str(ref newval);

        return ret; 
    }
}