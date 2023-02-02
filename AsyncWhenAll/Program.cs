var task1 = ReadFileAsStringAsync("t1.txt");
var task2 = ReadFileAsStringAsync("t2.txt");
var task3 = ReadFileAsStringAsync("t3.txt");

DoSomeWork();

var t = await Task.WhenAll(task1, task2, task3);

Console.WriteLine($"{t[0]}, {t[1]}, {t[2]}");

async Task<string> ReadFileAsStringAsync(string fileName)
{
    await Task.Delay(1000);
    return await File.ReadAllTextAsync(fileName);
}

void DoSomeWork()
{
    Console.WriteLine("Do some work");
}