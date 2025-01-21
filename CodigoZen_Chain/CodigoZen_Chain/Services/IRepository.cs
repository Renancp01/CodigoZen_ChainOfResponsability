namespace CodigoZen_Chain.Services;

public interface IRepository
{
    Task Handle(Order order);
}