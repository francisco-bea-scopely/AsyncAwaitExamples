var task = ReadFileAsStringAsync("t1.txt");

Console.WriteLine("Press Enter to exit");
Console.ReadLine();

async Task<string> ReadFileAsStringAsync(string fileName)
{
    await Task.Delay(1000);
    return await File.ReadAllTextAsync(fileName);
}

async Task BuggedCode()
{
    using (var httpClient = new HttpClient())
    {
        try
        {
            httpClient.PostAsync("www.google.com", new StringContent("content"));
        }
        catch
        {
            Console.WriteLine("Error");
        }
    }
}