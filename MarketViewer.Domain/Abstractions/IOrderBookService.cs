using MarketViewer.Domain.Models;

namespace MarketViewer.Domain.Abstractions;

public interface IOrderBookService
{
    public Task<OrderBook> GetCurrentOrderBook();
}
