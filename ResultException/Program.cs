var t1 = ReadFileAsStringAsync("t1.txt").Result;
var t2 = ReadFileAsStringAsync("t2.txt").Result;
var t3 = ReadFileAsStringAsync("t3.txt").Result;

Console.WriteLine($"{t1}, {t2}, {t3}");

async Task<string> ReadFileAsStringAsync(string fileName)
{
    await Task.Delay(1000);
    return await File.ReadAllTextAsync(fileName);
}