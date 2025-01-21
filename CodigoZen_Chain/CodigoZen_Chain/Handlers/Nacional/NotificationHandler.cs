namespace CodigoZen_Chain.Handlers.Nacional;

public class NotificationHandler : OrderHandlerBase
{
    public override Order Process(Order order)
    {
        if (order.IsValid)
        {
            order.NotificacaoEnviada = true;
            Console.WriteLine($"Order {order.Id}: Notification sent.");
        }

        return order;
    }

    public override bool CanHandle(FornecedorType fornecedorType) => fornecedorType == FornecedorType.Nacional;
}