namespace CodigoZen_Chain;

public class Order
{
    public int Id { get; set; }
    public decimal ValorTotal { get; set; }
    public bool IsValid { get; set; }
    public bool Desconto { get; set; }
    public bool NotificacaoEnviada { get; set; }
    public decimal IofAmount { get; set; }
    public FornecedorType Fornecedor { get; set; }
}

public enum FornecedorType
{
    Nacional,
    Internacional
}