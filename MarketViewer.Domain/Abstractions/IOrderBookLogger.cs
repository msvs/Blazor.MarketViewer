using MarketViewer.Domain.Models;

namespace MarketViewer.Domain.Abstractions;

public interface IOrderBookLogger
{
    public Task Log(OrderBook orderBook);
}
