namespace CodigoZen_Chain.Handlers.Internacional;

public class IofHandler : OrderHandlerBase
{
    public override Order Process(Order order)
    {
        if (order.Fornecedor == FornecedorType.Internacional && order.IsValid)
        {
            order.IofAmount = order.ValorTotal * 0.06m; // 6% de IOF
            Console.WriteLine($"Order {order.Id} (Internacional): IOF applied. Amount: {order.IofAmount:C}");
        }

        return order;
    }

    public override bool CanHandle(FornecedorType fornecedorType) => fornecedorType == FornecedorType.Internacional;
}