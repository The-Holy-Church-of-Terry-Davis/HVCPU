using HVCPU.Types;
using HVCPU.VirtualHardware.Types;

namespace HVCPU.EngineTypes;

public class Scope
{
    public int Id { get; set; }
    public List<Tp> stack { get; set; } = new();

    public void Push(Tp value)
    {
        stack.Add(value);
    }

    public void Pop()
    {
        stack.RemoveAt(stack.Count - 1);
    }

    public void Flush()
    {
        stack = new();
    }
}

public class NRScope : Scope
{
    public new HVCPU.Mappings.NoRuntime.List<Tp> stack { get; set; } = new();
}