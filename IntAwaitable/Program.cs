using IntAwaitable;

var i = 1;

while (true)
{
    Console.WriteLine(i);
    await 2;

    i++;
}