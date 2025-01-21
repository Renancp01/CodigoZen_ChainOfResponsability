namespace CodigoZen_Chain.Handlers.Nacional;

public class NacionalValidationHandler : OrderHandlerBase
{
    public override Order Process(Order order)
    {
        if (order.Fornecedor == FornecedorType.Nacional)
        {
            order.IsValid = order.ValorTotal > 0;
            Console.WriteLine($"Order {order.Id} (Nacional): Validation {(order.IsValid ? "passed" : "failed")}.");
        }
        
        return order;
    }

    public override bool CanHandle(FornecedorType fornecedorType) => fornecedorType == FornecedorType.Nacional;
}