namespace HVCPU.Types;

public class Str : Vector<Chr>
{
    public new Pointer<string> vals{ get; set; }
    public new Block<string> mem { get; set; }

    public new Chr this[int index]
    {
        get {
            char c = vals.value[index];
            return new Chr(ref c);
        }

        set {
            string newstr = "";
            
            for(int i = 0; i < vals.value.Length; i++)
            {
                if(i == index)
                {
                    newstr = newstr + value.ptr.value;
                    continue;
                }

                newstr = newstr + vals.value[i];
            }

            vals.Set(newstr);
        }
    }

    public Str(ref string s)
    {
        vals = new Pointer<string>(ref s);
        mem = new Block<string>(1);
        mem[0] = s;
    }

    public bool Equals(object? val)
    {
        bool ret = true;
        Str cmp = (Str)val;

        for(int i = 0; i < vals.value.Length; i++)
        {
            if(cmp[i].ptr.value != vals.value[i])
            {
                ret = false;
            }
        }

        return ret;
    }

    public bool Equals(Str? cmp)
    {
        bool ret = true;

        for(int i = 0; i < vals.value.Length; i++)
        {
            if(cmp[i].ptr.value != vals.value[i])
            {
                ret = false;
            }
        }

        return ret;
    }

    public static Str operator +(Str str1, Str str2) {
        string newstr = str1.vals.value + str2.vals.value;
        Str ret = new Str(ref newstr);
        ret.Length = newstr.Length;
        return ret;
    }

    public static bool operator ==(Str val1, Str val2) => val1.Equals((object)val2);
    public static bool operator !=(Str val1, Str val2) => !val1.Equals((object)val2);
}