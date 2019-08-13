namespace StackExchangeParser
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IExchangeParser
    {
        Task ProcessDataAsync(CancellationToken cancellationToken = default);
    }
}