using MarketViewer.Domain.Abstractions;
using MarketViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketViewer.Infrastructure.Persistence
{
	/// <summary>
	/// InMemory implementation of <see cref="IOrderBookLogger"/> for debugging and demonstration
	/// </summary>
	public class InMemoryOrderBookLogger : IOrderBookLogger
	{
		private readonly List<OrderBook> _loggedOrderBooks;

		public InMemoryOrderBookLogger()
		{
			_loggedOrderBooks = new();
		}

		public Task Log(OrderBook orderBook)
		{
			_loggedOrderBooks.Add(orderBook);

			return Task.CompletedTask;
		}
	}
}
