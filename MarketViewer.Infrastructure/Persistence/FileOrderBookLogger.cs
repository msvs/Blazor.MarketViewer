using MarketViewer.Domain.Abstractions;
using MarketViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarketViewer.Infrastructure.Persistence
{
	public class FileOrderBookLogger : IOrderBookLogger
	{
		private readonly string _logPath = Path.Combine(AppContext.BaseDirectory, "orderBookLog.txt");

		public async Task Log(OrderBook orderBook)
		{
			var logMessage = $"{Environment.NewLine}{DateTime.UtcNow} - OrderBook: {JsonSerializer.Serialize(orderBook)}";

			await File.AppendAllTextAsync(_logPath, logMessage);
		}
	}
}
