var printEvenNumbersTask = PrintEvenNumbers();

while (Console.ReadKey().Key != ConsoleKey.Escape)
{
    DoSomeWork();
}

await printEvenNumbersTask;

async Task PrintEvenNumbers()
{
    await foreach (var number in GetEvenNumbers())
    {
        Console.WriteLine(number);
    }
}

async IAsyncEnumerable<int> GetEvenNumbers()
{
    var i = 0;

    while (true)
    {
        yield return i;
        await Task.Delay(TimeSpan.FromSeconds(1));

        i += 2;
    }
}

void DoSomeWork()
{
    Console.WriteLine("Do some work");
}