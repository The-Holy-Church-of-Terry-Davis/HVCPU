using System.Runtime.InteropServices;

namespace HVCPU.Helpers;

internal unsafe class LowLevel
{
    [DllImport("LLHelper.dll")]
    public static extern unsafe long GetCharPtr(char x);

    [DllImport("LLHelper.dll")]
    public static extern unsafe long GetBytePtr(byte x);

    [DllImport("LLHelper.dll")]
    public static extern unsafe long GetIntPtr(int x);

    [DllImport("LLHelper.dll")]
    public static extern unsafe MemoryTuple GetRawPtr(int size);
}   

struct MemoryTuple
{
    long item1;
    long item2;
}