var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

const int concurrencyLevel = 5;

var tasks = new List<Task<string>>();
var index = 0;

while (index < concurrencyLevel && index < files.Length)
{
    var file = files[index];
    Console.WriteLine($"<< Queuing up initial file {Path.GetFileName(file)}");
    tasks.Add(ReadFileAsStringAsync(file));
    index++;
}

while (tasks.Count > 0)
{
    var task = await Task.WhenAny(tasks);
    tasks.Remove(task);

    var text = await task;
    Console.WriteLine($">> File read: {text}");

    if (index < files.Length)
    {
        var file = files[index];
        Console.WriteLine($"<< Queuing up initial file {Path.GetFileName(file)}");
        tasks.Add(ReadFileAsStringAsync(file));
        index++;
    }
}

async Task<string> ReadFileAsStringAsync(string fileName)
{
    await Task.Delay(Random.Shared.Next(1000, 3000));
    return await File.ReadAllTextAsync(fileName);
}