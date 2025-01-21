namespace CodigoZen_Chain.Handlers;

public interface IOrderHandler
{
    void SetNext(IOrderHandler nextHandler);
    
    Order Handle(Order order);
    
    bool CanHandle(FornecedorType fornecedorType);
}