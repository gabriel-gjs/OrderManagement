namespace FirstApi.Products.DTOs;

public record CreateProductRequest(string Name, double Price, int Quantity);