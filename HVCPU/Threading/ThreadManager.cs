/*
    HVCPU only runs single threaded! So threads
    are actually just my owwn custom implementation
    of an async function.
*/


namespace HVCPU.Threading;

public class ThreadManager
{
    protected int wwa { get; set; } = 0;
    protected HVCPU.Mappings.NoRuntime.List<Thread> Threads { get; set; } = new();

    public Pointer<Thread> SpawnThread()
    {
        Thread t = new Thread();
        t.Id = GetNextId();

        Threads.Add(t);

        return new Pointer<Thread>(t);
    }

    public int GetNextId()
    {
        wwa++;
        return wwa - 1;
    }
}