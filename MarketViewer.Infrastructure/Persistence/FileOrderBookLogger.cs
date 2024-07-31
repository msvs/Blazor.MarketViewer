using MarketViewer.Domain.Abstractions;
using MarketViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketViewer.Infrastructure.Persistence
{
	public class FileOrderBookLogger : IOrderBookLogger
	{
		public Task Log(OrderBook orderBook)
		{
			throw new NotImplementedException();
		}
	}
}
