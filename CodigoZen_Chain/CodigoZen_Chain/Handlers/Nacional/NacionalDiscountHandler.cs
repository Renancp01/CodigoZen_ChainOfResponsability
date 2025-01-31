﻿using CodigoZen_Chain.Services;

namespace CodigoZen_Chain.Handlers.Nacional;

public class NacionalDiscountHandler : OrderHandlerBase
{
    private readonly IRepository _repository;

    public NacionalDiscountHandler(IRepository repository)
    {
        _repository = repository;
    }

    public override Order Process(Order order)
    {
        if (order.Fornecedor == FornecedorType.Nacional && order.IsValid && order.ValorTotal > 200)
        {
            order.ValorTotal *= 0.95m; // 5% de desconto
            order.Desconto = true;
            Console.WriteLine($"Order {order.Id} (Nacional): Discount applied.");
        }

        return order;
    }

    public override bool CanHandle(FornecedorType fornecedorType) => fornecedorType == FornecedorType.Nacional;
}