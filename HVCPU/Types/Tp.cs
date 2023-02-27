namespace HVCPU.Types;

public class Tp
{
    public string? name { get; set; }
    public Block<byte>? mem { get; set; }
    public object? rutime_obj { get; set; }
}