namespace CodigoZen_Chain.Handlers.Internacional;

public class InternacionalValidationHandler : OrderHandlerBase
{
    public override Order Process(Order order)
    {
        if (order.Fornecedor == FornecedorType.Internacional)
        {
            order.IsValid = order.ValorTotal > 100;
            Console.WriteLine($"Order {order.Id} (Internacional): Validation {(order.IsValid ? "passed" : "failed")}.");
        }
        return order;
    }

    public override bool CanHandle(FornecedorType fornecedorType) => fornecedorType == FornecedorType.Internacional;
}