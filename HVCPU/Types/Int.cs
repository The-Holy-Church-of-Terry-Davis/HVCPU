namespace HVCPU.Types;

public class Int : Tp
{
    public Pointer<int> Value { get; set; }
    public new Block<int> mem { get; set; }

    public Int(ref int val)
    {
        Value = new Pointer<int>(ref val);

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