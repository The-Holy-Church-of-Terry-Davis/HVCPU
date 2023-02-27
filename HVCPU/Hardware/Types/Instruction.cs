namespace HVCPU.VirtualHardware.Types;

public class Instruction 
{
    public InstructionType tp { get; set; }
    public object?[]? args { get; set; }
}

public enum InstructionType
{
    CreateMethod,
    CreateVar,
    SystemCall,
    VarReference,
    MethodCall
}