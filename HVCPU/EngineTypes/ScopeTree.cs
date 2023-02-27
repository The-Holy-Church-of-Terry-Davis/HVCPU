namespace HVCPU.EngineTypes;

public class ScopeTree
{
    public Dictionary<int, Scope> scopes = new();
    public int HighestIndex = 0;

    public Scope AddScope()
    {
        Scope scp = new Scope();
        scopes.Add(HighestIndex + 1, scp);

        HighestIndex = HighestIndex + 1;
        scp.Id = HighestIndex;

        return scp;
    }
}