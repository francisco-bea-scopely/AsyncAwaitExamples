var t1 = ReadFileAsString("t1.txt");
var t2 = ReadFileAsString("t2.txt");
var t3 = ReadFileAsString("t3.txt");

Console.WriteLine($"{t1}, {t2}, {t3}");

string ReadFileAsString(string fileName)
{
    Thread.Sleep(1000);
    return File.ReadAllText(fileName);
}