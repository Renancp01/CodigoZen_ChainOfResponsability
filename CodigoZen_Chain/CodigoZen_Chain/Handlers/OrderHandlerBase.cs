namespace CodigoZen_Chain.Handlers;

public abstract class OrderHandlerBase : IOrderHandler
{
    private IOrderHandler? _nextHandler;

    public void SetNext(IOrderHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public Order Handle(Order order)
    {
        var processedOrder = Process(order);
        return _nextHandler?.Handle(processedOrder) ?? processedOrder;
    }

    public abstract Order Process(Order order);
    
    public abstract bool CanHandle(FornecedorType fornecedorType);
}