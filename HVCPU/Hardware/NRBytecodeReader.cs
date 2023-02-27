using HVCPU.Helpers;
using HVCPU.VirtualHardware.Types;
using HVCPU.Mappings.NoRuntime;

namespace HVCPU.VirtualHardware;

public class NRBytecodeReader : BytecodeReader
{
    public new HVCPU.Mappings.NoRuntime.List<Instruction> instructions { get; set; } = new();
}