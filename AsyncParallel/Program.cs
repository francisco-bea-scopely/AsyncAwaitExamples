var task1 = ReadFileAsStringAsync("t1.txt");
var task2 = ReadFileAsStringAsync("t2.txt");
var task3 = ReadFileAsStringAsync("t3.txt");

DoSomeWork();

var t1 = await task1;
var t2 = await task2;
var t3 = await task3;

Console.WriteLine($"{t1}, {t2}, {t3}");

async Task<string> ReadFileAsStringAsync(string fileName)
{
    await Task.Delay(1000);
    return await File.ReadAllTextAsync(fileName);
}

void DoSomeWork()
{
    Console.WriteLine("Do some work");
}