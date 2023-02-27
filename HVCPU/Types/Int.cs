namespace HVCPU.Types;

public class Int : Tp
{
    public Pointer<int> Value { get; set; }
    public new Block<int> mem { get; set; }

    public Int(int val)
    {
        Value = new Pointer<int>(val);

        mem = new Block<int>(Value);
    }

    public int GetValue()
    {
        return Value.Dereference();
    }

    public void SetValue(int val)
    {
        Value.Set(val);
    }
}