using HVCPU.VirtualHardware.Types;
using HVCPU.EngineTypes;

namespace HVCPU.VirtualHardware;

public class BytecodeReader
{
    public List<Instruction> instructions { get; set; } = new();
    protected Block<byte> bytes { get; set; } = new Block<byte>(1);
    protected int pos { get; set; }

    protected ReaderContext ctx { get; set; }

    public Instruction ReadNextInstruction()
    {
        switch(bytes[pos])
        {
            case 0xA1:
            {
                Instruction inst = new Instruction();
                inst.tp = InstructionType.CreateMethod;

                pos = pos + 1;

                inst.args = new object[] { ReadNextRuntimeString() };

                ctx = ReaderContext.METHOD;
                
                return inst;
            }

            case 0xA2:
            {
                Instruction inst = new Instruction();
                inst.tp = InstructionType.CreateVar;

                pos = pos + 1;
                int size = (int)bytes[pos];

                pos = pos + 1;
                VariableType tp = ReadType();

                pos = pos + 1;
                string name = ReadNextRuntimeString();

                pos = pos + 1;
                object? value = ReadValue(tp);

                pos = pos + 1;

                inst.args = new object[] { size, tp, name, value };

                return inst;
            }
        }

        return new();
    }

    public object? ReadValue(VariableType tp)
    {
        switch(tp)
        {
            case VariableType.Type:
            {
                Block<byte> t = ReadToNext(0xF4);
                return null; //This case will need to parse variable names
            }
            
            case VariableType.Int:
            {
                Block<byte> bt = ReadToNext(0xF4);
                return (int)bt[1];
            }
        }

        return null;
    }

    public Block<byte> ReadToNext(byte indicator)
    {
        int block_start = pos;
        int block_end = block_start;

        for(int i = block_start; i < bytes.Length; i++)
        {
            if(bytes[i] == indicator)
            {
                block_end = i;
                pos = i;
                break;
            }
        }

        return bytes.Slice(block_start).Slice(block_end);
    }

    public VariableType ReadType()
    {
        switch(bytes[pos])
        {
            case 0xD1:
            {
                return VariableType.Type;
            }
        }

        return VariableType.Null;
    }

    public string ReadNextRuntimeString()
    {
        switch(bytes[pos])
        {
            case 0xF2:
            {
                string ret = "";
                for(int i = pos; i < bytes.Length; i++)
                {
                    if(bytes[i] == 0xF2)
                    {
                        pos = i;
                        break;
                    }

                    ret = ret + (char)bytes[i];
                }

                return ret;
            }
        }

        return "";
    }

    public int GetInstructionEnd()
    {
        for(int i = pos; i < bytes.Length; i++)
        {
            switch(bytes[i])
            {
                case 0xF1:
                {
                    return i;
                }
            }
        }

        return pos;
    }

    public void Reset(Block<byte> bts)
    {
        instructions = new();
        bytes = bts;
        pos = 0;
    }
}

public enum ReaderContext
{
    BASE,
    METHOD,
    CODEBLOCK
}