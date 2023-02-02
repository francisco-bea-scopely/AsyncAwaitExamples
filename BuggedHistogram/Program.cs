var width = 1024;
var height = 768;
var numberOfColors = 16;

var image = InitializeImage(width, height, numberOfColors);

var histogram = GenerateHistogram(image, numberOfColors);
var buggedHistogram = await BuggedHistogram(image, numberOfColors);
var lockedHistogram = await LockedHistogram(image, numberOfColors);

Console.WriteLine(string.Join(", ", histogram));
Console.WriteLine(string.Join(", ", buggedHistogram));
Console.WriteLine(string.Join(", ", lockedHistogram));

static int[,] InitializeImage(int width, int height, int numberOfColors)
{
    var image = new int[768, 1024];

    for (var i = 0; i < height; i++)
    {
        for (var j = 0; j < width; j++)
        {
            image[i, j] = Random.Shared.Next(numberOfColors);
        }
    }

    return image;
}

int[] GenerateHistogram(int[,] image, int numberOfColors)
{
    var histogram = Enumerable.Repeat(0, numberOfColors).ToArray();

    for (int i = 0; i < image.GetLength(0); i++)
    {
        for (var j = 0; j < image.GetLength(1); j++)
        {
            var color = image[i, j];
            histogram[color]++;
        }
    }

    return histogram;
}

void FillHistogram(int[] histogram, int[,] image, int numberOfColors, int iMin, int iMax, int jMin, int jMax)
{
    for (int i = iMin; i < iMax; i++)
    {
        for (var j = jMin; j < jMax; j++)
        {
            var color = image[i, j];
            histogram[color]++;
        }
    }
}

async Task<int[]> BuggedHistogram(int[,] image, int numberOfColors)
{
    var histogram = Enumerable.Repeat(0, numberOfColors).ToArray();

    const int degreeOfParallelism = 4;

    var halfHeight = image.GetLength(0) / 2;
    var halfWidth = image.GetLength(1) / 2;
    var halfDegreeOfParallelism = degreeOfParallelism / 2;

    var tasks = new List<Task>();
    for (int i = 0; i < halfDegreeOfParallelism; i++)
    {
        for (var j = 0; j < halfDegreeOfParallelism; j++)
        {
            var iMin = i * halfHeight;
            var iMax = (i + 1) * halfHeight;
            var jMin = j * halfWidth;
            var jMax = (j + 1) * halfWidth;

            var task = Task.Run(() => FillHistogram(histogram, image, numberOfColors, iMin, iMax, jMin, jMax));
            tasks.Add(task);
        }
    }

    await Task.WhenAll(tasks);

    return histogram;
}


async Task<int[]> LockedHistogram(int[,] image, int numberOfColors)
{
    var histogram = Enumerable.Repeat(0, numberOfColors).ToArray();

    const int degreeOfParallelism = 4;

    var halfHeight = image.GetLength(0) / 2;
    var halfWidth = image.GetLength(1) / 2;
    var halfDegreeOfParallelism = degreeOfParallelism / 2;

    var tasks = new List<Task>();
    for (int i = 0; i < halfDegreeOfParallelism; i++)
    {
        for (var j = 0; j < halfDegreeOfParallelism; j++)
        {
            var iMin = i * halfHeight;
            var iMax = (i + 1) * halfHeight;
            var jMin = j * halfWidth;
            var jMax = (j + 1) * halfWidth;

            var task = Task.Run(() => LockFillHistogram(histogram, image, numberOfColors, iMin, iMax, jMin, jMax));
            tasks.Add(task);
        }
    }

    await Task.WhenAll(tasks);

    return histogram;
}


void LockFillHistogram(int[] histogram, int[,] image, int numberOfColors, int iMin, int iMax, int jMin, int jMax)
{
    for (int i = iMin; i < iMax; i++)
    {
        for (var j = jMin; j < jMax; j++)
        {
            var color = image[i, j];

            lock (histogram)
            {
                histogram[color]++;
            }
        }
    }
}