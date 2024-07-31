using MarketViewer.Domain.Models;
using static Blazor.MarketViewer.ViewModels.OrderBookVM;

namespace Blazor.MarketViewer.ViewModels
{
	public class OrderBookVM
	{
		public IEnumerable<OrdersStack> SellOrders { get; init; } = [];

		public IEnumerable<OrdersStack> BuyOrders { get; init; } = [];

		public IEnumerable<Order> RawAsks { get; init; } = [];

		public IEnumerable<Order> RawBids { get; init; } = [];

		public string MarketName { get; init; } = string.Empty;

		public DateTime DateTimeUtc { get; init; }

		public static OrderBookVM FromDomain(OrderBook orderBook, int digitsPrecision = 0, int takeCount = 20)
		{
			var asksGrouped = orderBook.SellOrders.GroupBy(a => (int)Math.Floor(a.Price));
			var asks = asksGrouped.Take(takeCount);

			var bidsGrouped = orderBook.BuyOrders.GroupBy(a => (int)Math.Floor(a.Price));
			var bids = bidsGrouped.Take(takeCount);

			var orderBookVM = new OrderBookVM()
			{
				SellOrders = asks.Select(g => new OrdersStack(g.Key, g.Select(o => o))),
				BuyOrders = bids.Select(g => new OrdersStack(g.Key, g.Select(o => o))),
				RawAsks = orderBook.SellOrders,
				RawBids = orderBook.BuyOrders,
				MarketName = orderBook.MarketName,
				DateTimeUtc = orderBook.DateTimeUtc
			};
			return orderBookVM;
		}

		public record OrdersStack(decimal Price, IEnumerable<Order> Orders);
	}
}
