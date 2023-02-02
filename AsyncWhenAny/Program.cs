var task1 = ReadFileAsStringAsync("t1.txt");
var task2 = ReadFileAsStringAsync("t2.txt");
var task3 = ReadFileAsStringAsync("t3.txt");

DoSomeWork();

var tasks = new [] { task1, task2, task3 };
var taskList = tasks.ToList();

for (var i = 0; i < tasks.Length; i++)
{
    var task = await Task.WhenAny(taskList);
    var t = await task;

    taskList.Remove(task);

    Console.WriteLine($"task{Array.IndexOf(tasks, task) + 1} finished: {t}");
}

async Task<string> ReadFileAsStringAsync(string fileName)
{
    await Task.Delay(Random.Shared.Next(1000, 3000));
    return await File.ReadAllTextAsync(fileName);
}

void DoSomeWork()
{
    Console.WriteLine("Do some work");
}