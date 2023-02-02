var cache = new Dictionary<string, string>();

for (var i = 0; i < 10; i++)
{
    var t1 = await ReadFileAsStringAsync("t1.txt");
    var t2 = await ReadFileAsStringAsync("t2.txt");
    var t3 = await ReadFileAsStringAsync("t3.txt");

    await Task.Delay(1000);

    Console.WriteLine($"{t1}, {t2}, {t3}");
}


async ValueTask<string> ReadFileAsStringAsync(string fileName)
{
    if (!cache.TryGetValue(fileName, out var text))
    {
        Thread.Sleep(1000);
        text = await File.ReadAllTextAsync(fileName);

        cache.Add(fileName, text);
    }

    return text;
}