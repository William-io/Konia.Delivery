using Konia.Delivery.App.Domain.Orders;
using Konia.Delivery.App.Infrastructure;

namespace Konia.Delivery.App.Endpoints.Orders;

public class OrderPost
{
    public static string Template => "/orders";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(OrderRequest orderRequest, DataContext context)
    {
        var order = new Order(orderRequest.Number);

        if (!order.IsValid)
            return Results.BadRequest(order.Notifications);

        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();

        return Results.Created($"/orders/{order.Id}", order.Id);
    }
}

