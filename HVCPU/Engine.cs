using HVCPU.VirtualHardware.Types;
using HVCPU.VirtualHardware;
using HVCPU.Types;

namespace HVCPU;

public class Engine
{
    public BytecodeReader reader { get; set; } = new();
    public HVCPU.Mappings.NoRuntime.Dictionary<int, Tp> Caches { get; set; } = new();
    public List<Instruction> OrderedProgram { get; set; } = new();
}
