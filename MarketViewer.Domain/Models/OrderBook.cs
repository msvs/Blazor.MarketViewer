namespace MarketViewer.Domain.Models;

public class OrderBook
{
    public List<Order> SellOrders { get; init; } = [];

    public List<Order> BuyOrders { get; init; } = [];

    public Guid Id { get; } = Guid.NewGuid();

    public string MarketName { get; init; } = string.Empty;

    public DateTime DateTimeUtc { get; init; }
}

public record Order(OrderType Type, decimal Amount, decimal Price);

public enum OrderType : short
{
    Buy,
    Sell
}