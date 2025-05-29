namespace OrderManagementAPI.API.DTOs;

public record CreateProductRequest(string Name, double Price, int Quantity);