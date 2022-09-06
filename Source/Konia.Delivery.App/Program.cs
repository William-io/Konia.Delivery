using Konia.Delivery.App.Endpoints.Orders;
using Konia.Delivery.App.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<DataContext>(builder.Configuration["ConnectionString:KoniaDeliveryDb"]);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();


#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Konia.Delivery.App",
        Version = "v1",
        Description = "API construída - konia desafio",
        Contact = new OpenApiContact
        {
            Name = "William Gonçalves da Silva",
            Email = "williamgsilva@live.com",
            Url = new Uri("https://william-io.github.io/site/")
        },
    });
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#region /orders - POST & GET
app.MapMethods(OrderPost.Template, OrderPost.Methods, OrderPost.Handle);
app.MapMethods(OrderGetAll.Template, OrderGetAll.Methods, OrderGetAll.Handle);
app.MapMethods(OrderDelete.Template, OrderDelete.Methods, OrderDelete.Handle);

#endregion

app.Run();
