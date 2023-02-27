namespace HVCPU;

//Represents a section of memory that has been allocated by the Runtime/CPU
public class Block<T>
{
    protected Pointer<T>[] mem { get; set; } = new Pointer<T>[1];
    public int Length { get; set; } = 1;

    public T this[int i]
    {
        get => mem[i].value;
        set => mem[i].value = value;
    }

    public Block(int size)
    {
        mem = new Pointer<T>[size];
        Length = size;
    }

    public Block(Pointer<T> ptr)
    {
        mem = new Pointer<T>[] { ptr };
        Length = 1;
    }

    public Block(Pointer<T>[] pointers)
    {
        mem = pointers;
        Length = pointers.Length;
    }

    public void Extend(int size)
    {
        Length += size;

        Pointer<T>[]? newmem = new Pointer<T>[Length + size];

        for(int i = 0; i < Length; i++)
        {
            newmem[i] = mem[i];
        }

        mem = newmem;
    }

    public Block<T> Slice(int index)
    {
        Block<T> ret = new Block<T>(Length - index);
        Pointer<T>[]? vals = new Pointer<T>[Length - index];

        for(int i = index; i < Length; i++)
        {
            vals[i - index] = mem[i];
        }

        ret.mem = vals;

        return ret;
    }

    public T GetIndex(int index)
    {
        return mem[index].value;
    }

    public void SetIndex(Pointer<T> val, int index)
    {
        mem[index] = val;
    }

    public void SetIndex(int index, Pointer<T> val)
    {
        mem[index] = val;
    }

    public Pointer<T> GetPtr(int index)
    {
        return mem[index];
    }
}

public ref struct StackBlock<T>
{

}