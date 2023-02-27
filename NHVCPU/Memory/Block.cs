namespace HVCPU.Memory;

public class Block<T>
{
    public T[] vals { get; set; } = new T[1];
    public int Length { get; set; } = 1;

    public T this[int index]
    {
        get {
            return vals[index];
        }

        set => vals[index] = value;
    }

    public Block(T[] v)
    {
        vals = v;
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

}