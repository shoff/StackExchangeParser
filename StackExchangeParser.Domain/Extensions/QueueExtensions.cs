namespace StackExchangeParser.Domain.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using ChaosMonkey.Guards;

    public static class QueueExtensions
    {
        public static void EnqueueChunk<T>(this Queue<T> queue, IEnumerable<T> chunks)
        {
            Guard.IsNotNull(queue, nameof(queue));
            var enumerable = chunks as T[] ?? chunks.ToArray();
            Guard.IsNotNull(enumerable, nameof(chunks));
            foreach (var chunk in enumerable)
            {
                if (!queue.Contains(chunk))
                {
                    queue.Enqueue(chunk);
                }
            }
        }
    }
}