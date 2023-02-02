await foreach (var number in GetEvenNumbers())
{
    Console.WriteLine(number);
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