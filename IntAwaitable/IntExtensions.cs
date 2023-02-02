using System.Runtime.CompilerServices;

namespace IntAwaitable
{
    public static class IntExtensions
    {
        public static TaskAwaiter GetAwaiter(this int seconds)
        {
            var delay = TimeSpan.FromSeconds(seconds);

            var task = Task.Delay(delay);

            return task.GetAwaiter();
        }
    }
}
