namespace HVCPU.VirtualHardware.Types;

public record Register(Block<byte> cache, RegisterType tp);

public enum RegisterType
{
    R1, //Priority registers
    R2,
    R3,
    C1, //Fallback registers
    C2,
    C3
}