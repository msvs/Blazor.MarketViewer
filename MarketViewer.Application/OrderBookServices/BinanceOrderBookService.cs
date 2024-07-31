using Binance.Net.Clients;
using MarketViewer.Domain.Abstractions;
using MarketViewer.Domain.Models;
using System.Diagnostics;

namespace MarketViewer.Application.OrderBookServices;

public class BinanceOrderBookService : IOrderBookService
{
    private readonly BinanceRestClient _binanceRestClient;
    private readonly string _marketName;
    private readonly IOrderBookLogger _orderBookLogger;

	public BinanceOrderBookService(IOrderBookLogger orderBookLogger)
	{
		_binanceRestClient = new BinanceRestClient();
		_marketName = "Binance";
		Debug.WriteLine($"{nameof(BinanceOrderBookService)} ctor");

		_orderBookLogger = orderBookLogger;
	}

	public async Task<OrderBook> GetCurrentOrderBook()
    {
        // hardcoded for demo
        var pair = "BTCUSDT"; // "BTCUSDT", "BTCEUR";
        
        var binanceOrderBook = await _binanceRestClient.SpotApi.ExchangeData.GetOrderBookAsync(pair);

        var asks = binanceOrderBook.Data.Asks;
        var bids = binanceOrderBook.Data.Bids;

        var orderBook = new OrderBook()
        {
            MarketName = _marketName,
            SellOrders = asks.Select(o => new Order(OrderType.Sell, o.Quantity, o.Price)),
            BuyOrders = bids.Select(o => new Order(OrderType.Buy, o.Quantity, o.Price)),
            DateTimeUtc = DateTime.UtcNow
        };

        await _orderBookLogger.Log(orderBook);
        return orderBook;
    }
}
