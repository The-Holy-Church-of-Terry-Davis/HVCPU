using HVCPU;

namespace Tester;

public class Program
{
    public static void Main()
    {
        byte bt = 0xA;

        Pointer<byte> ptr = new Pointer<byte>(ref bt);

        SetPtrBt(0xB, ptr);

        Console.WriteLine((int)bt);
    }

    public static void SetPtrBt(byte newval, Pointer<byte> ptr)
    {
        ptr.value = newval;
    }
}