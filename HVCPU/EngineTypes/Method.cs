using HVCPU.Types;

namespace HVCPU.EngineTypes;

public class Method<T>
{
    public ScopeTree Stack { get; set; } = new();
    public HVCPU.Mappings.NoRuntime.List<Tp> Parameters { get; set; }

    public void Invoke()
    {
        
    }
}