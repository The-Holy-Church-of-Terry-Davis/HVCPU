namespace HVCPU;

public unsafe class UnsafePtr
{
    public ref byte bt { get => ref bt; }

    public ref byte this[int index]
    {
        get {
            fixed(byte *var = &bt)
            {
                return ref var[index];
            }
        }
    }

    public UnsafePtr(ref byte val)
    {
        bt = val;
    }

    public Block<byte> AsBlock(ref byte firstval, int size)
    {
        Block<byte> ret = new Block<byte>(size);
        ret.SetIndex(0, new Pointer<byte>(ref firstval));

        fixed(byte *ptr = &firstval)
        {
            for(int i = 1; i < size; i++)
            {
                ret.SetIndex(i, new Pointer<byte>(ref ptr[i]));
            }
        }

        return ret;
    }
}