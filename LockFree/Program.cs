var width = 1024;
var height = 768;
var numberOfColors = 16;

var image = InitializeImage(width, height, numberOfColors);

var histogram = GenerateHistogram(image, numberOfColors);
var lockFreeHistogram = await GenerateHistogramLockFree(image, numberOfColors);

Console.WriteLine(string.Join(", ", histogram));
Console.WriteLine(string.Join(", ", lockFreeHistogram));

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
    int iMin = 0;
    int iMax = image.GetLength(0);
    int jMin = 0;
    int jMax = image.GetLength(1);

    return GeneratePartialHistogram(image, numberOfColors, iMin, iMax, jMin, jMax);
}

int[] GeneratePartialHistogram(int[,] image, int numberOfColors, int iMin, int iMax, int jMin, int jMax)
{
    var histogram = Enumerable.Repeat(0, numberOfColors).ToArray();

    for (int i = iMin; i < iMax; i++)
    {
        for (var j = jMin; j < jMax; j++)
        {
            var color = image[i, j];
            histogram[color]++;
        }
    }

    return histogram;
}

async Task<int[]> GenerateHistogramLockFree(int[,] image, int numberOfColors)
{
    const int degreeOfParallelism = 4;

    var halfHeight = image.GetLength(0) / 2;
    var halfWidth = image.GetLength(1) / 2;
    var halfDegreeOfParallelism = degreeOfParallelism / 2;

    var tasks = new List<Task<int[]>>();
    for (int i = 0; i < halfDegreeOfParallelism; i++)
    {
        for (var j = 0; j < halfDegreeOfParallelism; j++)
        {
            var iMin = i * halfHeight;
            var iMax = (i + 1) * halfHeight;
            var jMin = j * halfWidth;
            var jMax = (j + 1) * halfWidth;

            var task = Task.Run(() => GeneratePartialHistogram(image, numberOfColors, iMin, iMax, jMin, jMax));
            tasks.Add(task);
        }
    }

    var partialHistograms = await Task.WhenAll(tasks);

    var histogram = Enumerable.Repeat(0, numberOfColors).ToArray();
    foreach (var partialHistogram in partialHistograms)
    {
        for (int i = 0; i < numberOfColors; i++)
        {
            histogram[i] += partialHistogram[i];
        }
    }

    return histogram;
}