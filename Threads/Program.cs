Console.WriteLine("Threads demo");

const int maxThreads = 1000;

Console.WriteLine($"Press Enter to create {maxThreads} threads");
Console.ReadLine();

Console.WriteLine($"Creating {maxThreads} threads...");
var threads = new List<Thread>();
for (var i = 0; i < maxThreads; i++)
{
    var thread = new Thread(ThreadMethod)
    {
        IsBackground = true
    };
    threads.Add(thread);
    thread.Start();
}

Console.WriteLine($"{maxThreads} threads created");
Console.WriteLine("Press Enter to terminate");
Console.ReadLine();

Console.WriteLine($"{maxThreads} threads terminated");

void ThreadMethod()
{
    Thread.Sleep(TimeSpan.FromMinutes(10));
}