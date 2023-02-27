namespace HVCPU.Mappings.NoRuntime;

public struct Void { } /*   Void is special in the sense that its a "shared" type. 
                            Which means the runtime will be sharing this type with 
                            runnning processes without adding any overlay       */

public struct Boolean { }
public struct Char { }
public struct SByte { }
public struct Byte { }
public struct Int16 { }
public struct UInt16 { }
public struct Int32 { }
public struct UInt32 { }
public struct Int64 { }
public struct UInt64 { }
public struct IntPtr { }
public struct UIntPtr { }
public struct Single { }
public struct Double { }

public class List<T>
{
    protected T[] Values { get; set; } = new T[] {};
    public int Length { get; set; } = 1;

    public T this[int index]
    {
        get => Values[index];
        set => Values[index] = value;
    }

    public IEnumerable<T> GetEnumerable()
    {
        foreach(T v in Values)
        {
            yield return v;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach(T val in Values)
        {
            yield return val;
        }
    }

    public void Add(T val)
    {
        ++Length;
        T[] n = new T[Values.Length + 1];

        for(int i = 0; i < Values.Length; i++)
        {
            n[i] = Values[i];
        }

        n[n.Length - 1] = val;
    }

    public T GetIndex(int i)
    {
        return Values[i];
    }

    public Block<T> AsBlock()
    {
        Block<T> blk = new Block<T>(Length);

        for(int i = 0; i < Length; i++)
        {
            blk.SetIndex(i, new Pointer<T>(ref Values[i]));
        }

        return blk;
    }
}

public struct KeyValuePair<T, T1>
{
    public T Key { get; set; }
    public T1 Value { get; set; }

    public KeyValuePair(T k, T1 v)
    {
        Key = k;
        Value = v;
    }
}

public class Dictionary<T, T1>
{
    protected List<KeyValuePair<T, T1>> vals { get; set; } = new List<KeyValuePair<T, T1>>();
    public int Length { get; set; } = 1;

    public T1 this[T index]
    {
        get => FindTIndex(index);
        set => SetValue(index, value);
    }

    public IEnumerator<KeyValuePair<T, T1>> GetEnumerator()
    {
        return vals.GetEnumerable().GetEnumerator();
    }

    protected T1 FindTIndex(T comp)
    {
        foreach(KeyValuePair<T, T1> v in vals)
        {
            if(v.Key.Equals(comp))
            {
                return v.Value;
            }
        }

        return vals[0].Value;
    }

    protected void SetValue(T index, T1 value)
    {
        this[index] = value;
    }

    public T1? GetFromKey(T val)
    {
        for(int i = 0; i < vals.Length; i++)
        {
            KeyValuePair<T, T1> ind = vals[i];
            if(ind.Key.Equals(val))
            {
                return ind.Value;
            }
        }

        return vals.GetIndex(0).Value;
    }

    public void Add(T key, T1 value)
    {
        KeyValuePair<T, T1> toadd = new(key, value);
        vals.Add(toadd);
    }

    public void Add(KeyValuePair<T, T1> val)
    {
        vals.Add(val);
    }
}