using Flunt.Validations;

namespace Konia.Delivery.App.Domain.Orders;

public class Order : Entity
{
    public Order(double number)
    {
        Number = number;
        Date = DateTime.Now;

        Validating();
    }

    public double Number { get; protected set; }
    public DateTime Date { get; protected set; }


    //Utilizando o FLUNT para validações
    //Não pode ser null
    private void Validating()
    {
        var contract = new Contract<Order>()
            .IsGreaterOrEqualsThan(Number, 1, "Number", "Digite um número acima ou igual á 1")
            .AreNotEquals(Number, Number, "Number", "Número de pedido existente!!");
        AddNotifications(contract);
    }
}