namespace HVCPU;

//Represents a section of memory that has been allocated by the Runtime/CPU
public class Block<T>
{
    protected T[] mem { get; set; } = new T[1];
    public int Length { get => mem.Length; private set {
        Length = value;
    } }

    public T this[int i]
    {
        get => mem[i];
        set => mem[i] = value;
    }

    public Block(int size)
    {
        mem = new T[size];
        Length = size;
    }

    public Block(Pointer<T> ptr)
    {
        mem[1] = ptr.value;
        Length = 1;
    }

    public void Extend(int size)
    {
        Length += size;

        T[]? newmem = new T[Length + size];

        for(int i = 0; i < Length; i++)
        {
            newmem[i] = mem[i];
        }

        mem = newmem;
    }

    public Block<T> Slice(int index)
    {
        Block<T> ret = new Block<T>(Length - index);
        T[]? vals = new T[Length - index];

        for(int i = index; i < Length; i++)
        {
            vals[i - index] = mem[i];
        }

        ret.mem = vals;

        return ret;
    }

    public Pointer<T> GetPtr(int index)
    {
        return new Pointer<T>(mem[index]);
    }
}