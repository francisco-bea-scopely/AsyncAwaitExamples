Console.WriteLine("Even numbers (press Enter to cancel):");

var cancellationTokenSource = new CancellationTokenSource();
var task = Task.Run(() => CalculateEvenNumbers(cancellationTokenSource.Token));

Console.ReadLine();
cancellationTokenSource.Cancel();

try
{
    await task;
}
catch (OperationCanceledException)
{
    Console.WriteLine("Even number calculation canceled.");
}


async Task CalculateEvenNumbers(CancellationToken cancellationToken)
{
    var i = 0;
    while (true)
    {
        //if (cancellationToken.IsCancellationRequested)
        //{
        //    break;
        //}
        cancellationToken.ThrowIfCancellationRequested();

        if (i % 2 == 0)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            Console.WriteLine(i);
        }

        i++;
    }
}