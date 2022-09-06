using Konia.Delivery.App.Infrastructure;

namespace Konia.Delivery.App.Endpoints.Orders;

public class OrderGetAll
{
    public static string Template => "/orders";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(DataContext context)
    {
        var orders = context.Orders.ToList();

        var response = orders.Select(o => new OrderResponse
        (
            o.Id,
            o.Number,
            o.Date
        ));

        return Results.Ok(orders);
    }
}

