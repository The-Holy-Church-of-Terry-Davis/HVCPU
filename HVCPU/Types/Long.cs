namespace HVCPU.Types;

public class Long : Tp
{
    public Pointer<long> Value { get; set; }
    public new Block<long> mem { get; set; }

    public Long(ref long val)
    {
        Value = new Pointer<long>(val);

        mem = new Block<long>(Value);
    }

    public long GetValue()
    {
        return Value.Dereference();
    }

    public void SetValue(long val)
    {
        Value.Set(val);
    }
}