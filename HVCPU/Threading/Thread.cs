using HVCPU.Types;
using HVCPU.VirtualHardware.Types;

namespace HVCPU.Threading;

public class Thread
{
    public int Id { get; set; }
    public HVCPU.Mappings.NoRuntime.List<Instruction>? Instructions { get; set; }
    public bool HasExited { get; set; }
}