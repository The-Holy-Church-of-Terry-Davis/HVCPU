using HVCPU;

namespace Tester;

public class Program
{
    public static void Main()
    {
        byte bt = 0xA;
        Pointer<byte> newVar = new Pointer<byte>(bt);

        SetPtrBt(0xB, newVar);

        Console.WriteLine(newVar.value);
    }

    public static void SetPtrBt(byte newval, Pointer<byte> ptr)
    {
        ptr.value = newval;
    }
}