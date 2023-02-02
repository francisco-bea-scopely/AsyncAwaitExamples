Console.WriteLine("Even numbers (press Enter to cancel):");

var progress = new Progress<int>(evenNumber => Console.WriteLine($"Even number: {evenNumber}"));

var cancellationTokenSource = new CancellationTokenSource();
var task = Task.Run(() => CalculateEvenNumbers(progress, cancellationTokenSource.Token));

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


async Task CalculateEvenNumbers(IProgress<int> progress, CancellationToken cancellationToken)
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
            progress.Report(i);
        }

        i++;
    }
}