namespace Konia.Delivery.App.Endpoints.Orders
{
    public record OrderResponse(Guid Id, double deliveryNumber, DateTime Date);
}