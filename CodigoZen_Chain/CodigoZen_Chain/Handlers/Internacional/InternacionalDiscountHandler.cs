namespace CodigoZen_Chain.Handlers.Internacional;

public class InternacionalDiscountHandler : OrderHandlerBase
{
    public override Order Process(Order order)
    {
        if (order.Fornecedor == FornecedorType.Internacional && order.IsValid && order.ValorTotal > 500)
        {
            order.ValorTotal *= 0.90m; // 10% de desconto
            order.Desconto = true;
            Console.WriteLine($"Order {order.Id} (Internacional): Discount applied.");
        }
        return order;
    }

    public override bool CanHandle(FornecedorType fornecedorType) => fornecedorType == FornecedorType.Internacional;
}