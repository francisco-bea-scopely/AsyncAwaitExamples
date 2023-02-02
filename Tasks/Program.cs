Console.WriteLine("Threads demo");

const int maxTasks = 1000;

Console.WriteLine($"Press Enter to create {maxTasks} tasks");
Console.ReadLine();

Console.WriteLine($"Creating {maxTasks} tasks...");
var tasks = new List<Task>();
for (var i = 0; i < maxTasks; i++)
{
    var thread = Task.Run(TaskMethod);
}

Console.WriteLine($"{maxTasks} tasks created");
Console.WriteLine("Press Enter to terminate");
Console.ReadLine();

Console.WriteLine($"{maxTasks} tasks terminated");

async Task TaskMethod()
{
    await Task.Delay(TimeSpan.FromMinutes(10));
}