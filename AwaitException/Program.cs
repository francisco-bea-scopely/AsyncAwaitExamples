var t1 = await ReadFileAsStringAsync("t1.txt");
var t2 = await ReadFileAsStringAsync("t2.txt");
var t3 = await ReadFileAsStringAsync("t3.txt");

Console.WriteLine($"{t1}, {t2}, {t3}");

async Task<string> ReadFileAsStringAsync(string fileName)
{
    await Task.Delay(1000);
    return await File.ReadAllTextAsync(fileName);
}