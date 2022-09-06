using Konia.Delivery.App.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Konia.Delivery.App.Endpoints.Orders;

public class OrderDelete
{
    public static string Template => "/courses/{id}";

    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };

    public static Delegate Handle => Action;

    public static async Task<IResult> Action([FromRoute] Guid id, DataContext context)
    {
        //Deletar por ID
        var course = context.Orders.Where(c => c.Id == id).FirstOrDefault();

        context.Remove(course);
        await context.SaveChangesAsync();

        return Results.Ok();
    }
}