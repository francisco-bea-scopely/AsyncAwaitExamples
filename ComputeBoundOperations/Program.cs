var task = Task.Run(Compute);

var result = await task;

Console.WriteLine($"Result: {result}");

long Compute()
{
	const int length = 1000000;

	var result = 0L;

	for (int i = 0; i < length; i++)
	{
		result += i;
	}

	return result;
}