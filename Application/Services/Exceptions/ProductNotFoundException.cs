namespace OrderManagementAPI.Application.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException()
        : base("Produto não encontrado.") { }
    public ProductNotFoundException(string message)
        : base(message) { }
    public ProductNotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
}

